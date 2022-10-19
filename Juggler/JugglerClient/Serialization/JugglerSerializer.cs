using System.Reflection;
using JugglerClient.Attributes;

namespace JugglerClient.Serialization;

public class JugglerSerializer
{
    public string Serialize(object obj)
    {
        var type = obj.GetType();
        
        if (Attribute.GetCustomAttribute(obj.GetType(), typeof(PreservedAttribute)) 
            is not PreservedAttribute attribute)
            throw new Exception();

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        var result = "< " + type + "; " + "guid: " + attribute.Guid + "; ";

        foreach (var field in fields) 
            result += field.Name + ": " + field.GetValue(obj) + "; ";

        return result + "/>";
    }

    public T Deserialize<T>(byte[] bytes)
    {
        throw new NotImplementedException();
    }
}