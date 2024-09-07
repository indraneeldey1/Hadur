using API.Services;
using Common.Extensions;
using DAL;
using DAL.Attributes;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using StackExchange.Redis;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

IConfigurationBuilder configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
IConfigurationRoot configRoot = configuration.Build();
var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddSingleton<IRepoFactory, RepoFactory>();


Action logging = () =>
{
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();
};

Action caching = () =>
{
    builder.Services.AddSingleton<IConnectionMultiplexer>(o => 
        ConnectionMultiplexer.Connect(configRoot.GetValue<string>("CachingConnection.Host")));
};


// Database Actions
Action database = () =>
{
    try
    {
        string dbConString =
            $"Host={configRoot["DatabaseConnection:Host"]};Database={configRoot["DatabaseConnection:Database"]};" +
            $"Username={configRoot["DatabaseConnection:Username"]};Password={configRoot["DatabaseConnection:Password"]}";

        builder.Services.AddDbContextFactory<HadurContext>(options =>
            {
                options.UseNpgsql(dbConString, b => b.MigrationsAssembly("Hadur.Service.Database"));
            },
            ServiceLifetime.Singleton);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
  
};

logging.Invoke();
caching.Invoke();
database.Invoke();

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

Action repoFactory = () =>
{
    IRepoFactory factory = app.Services.GetService<IRepoFactory>() ?? throw new NullReferenceException();

    IEnumerable<Type> repos = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => p.CustomAttributes.Any(o => o.AttributeType == typeof(RepositoryAttribute)));

    foreach (Type repo in repos)
    {
        try
        {
            Type? repoInterface = repo.GetInterface($"I{repo.Name}");
            if (repoInterface != null)
            {
                factory.Create(app.Services.GetService(repoInterface)!);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
};

repoFactory.Invoke();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();