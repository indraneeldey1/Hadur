﻿using System.Diagnostics;
using Common.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions;

//based on https://dev.to/tomfletcher9/net-6-register-services-using-reflection-3156
public static class ServiceExtensions
{
  public static void RegisterServices(this IServiceCollection services, IConfiguration config)
  {
    // Define types that need matching
    Type scopedRegistration = typeof(ScopedRegistrationAttribute);
    Type singletonRegistration = typeof(SingletonRegistrationAttribute);
    Type transientRegistration = typeof(TransientRegistrationAttribute);

    var types = AppDomain.CurrentDomain.GetAssemblies()
                         .SelectMany(s => s.GetTypes())
                         .Where(p => p.IsDefined(scopedRegistration, false) || p.IsDefined(transientRegistration, false) ||
                                     p.IsDefined(singletonRegistration, false) && !p.IsInterface)
                         .Select(s => new 
                          {
                            Service = s.GetInterface($"I{s.Name}"), Implementation = s
                          })
                         .Where(x => x.Service != null);

    foreach (var type in types)
    {
      Debug.Assert(type.Service != null, "type.Service != null");
      
      if (type.Implementation.IsDefined(scopedRegistration, false))
      {
        services.AddScoped(type.Service, type.Implementation);
      }

      if (type.Implementation.IsDefined(transientRegistration, false))
      {
        services.AddTransient(type.Service, type.Implementation);
      }

      if (type.Implementation.IsDefined(singletonRegistration, false))
      {
        services.AddSingleton(type.Service, type.Implementation);
      }
    }
  }
}