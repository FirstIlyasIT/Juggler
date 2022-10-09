namespace JugglerClient;

public class StorageContext<T>
{
    public IList<JugglerList<T>> Lists { get; }

    public StorageContext(JugglerConfiguration configuration)
    {
        Lists = configuration.GetLists<T>();
    }

    public void Push()
    {

    }

    public void Update()
    {

    }

    public JugglerList<T> this[Type type]
    {
        get { return Lists.First(x => x.GetType() == type);}
    }
} 