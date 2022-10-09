namespace JugglerClient.StorageContext;

public abstract class JugglerConfiguration
{
    public Dictionary<Type, JugglerList<object>> Types { get; }

    protected JugglerConfiguration()
    {
        Types = new Dictionary<Type, JugglerList<object>>();
    }

    protected void AddType<T>() where T : object                
    {
        Types.Add(typeof(T), new JugglerList<object>());
    }
}