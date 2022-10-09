using JugglerClient.Connection;

namespace JugglerClient.StorageContext;

public class StorageContext
{
    private readonly Dictionary<Type, JugglerList<object>> _types;
    private readonly JugglerConnection _connection;

    public StorageContext(JugglerConfiguration configuration, JugglerConnection connection)
    {
        _connection = connection;
        _types = configuration.Types;
    }

    public void Push()
    {

    }

    public void Update()
    {

    }

    public JugglerList<T> Get<T>()
    {
        return _types[typeof(T)] as JugglerList<T> ?? throw new InvalidOperationException();
    }
} 