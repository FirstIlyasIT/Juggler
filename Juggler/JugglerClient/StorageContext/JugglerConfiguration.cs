namespace JugglerClient.StorageContext;

public abstract class JugglerConfiguration
{
    public Dictionary<Type, object> Types { get; }

    protected JugglerConfiguration()
    {
        Types = new Dictionary<Type, object>();
    }

    protected void AddType<T>()                 
    {
        Types.Add(typeof(T), new JugglerList<T>());
    }
}