using System.Diagnostics;
using System.Reflection;
using StackExchange.Redis;

namespace Common;

public static class HashEntryExt
{
    public static T ToObject<T>(this HashEntry[] entries) //where T : new()
    {
        //T model = new T();
        T model = Activator.CreateInstance<T>();
        Type modelType = typeof(T);
        
        PropertyInfo[] modelProperties = modelType.GetProperties();

        
        
        foreach (HashEntry entry in entries)
        {
            if (!modelProperties.Any(o => o.Name == entry.Name)) continue;
            
            FieldInfo field = modelType.GetField(entry.Name);
            field.SetValue(model, entry.Value.Box());
        }

        return model;
    }
}