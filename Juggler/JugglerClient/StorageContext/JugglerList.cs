namespace JugglerClient;

public abstract class JugglerList<T>
{
    private readonly StorageContext<T> _storageContext;

    protected JugglerList(StorageContext<T> storageContext)
    {
        _storageContext = storageContext;
    }
    public IList<T> ToList()
    {
        throw new NotImplementedException();
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }
}