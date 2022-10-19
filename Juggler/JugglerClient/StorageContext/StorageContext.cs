using System.Collections;
using System.Text;
using JugglerClient.Connection;
using JugglerClient.Serialization;

namespace JugglerClient.StorageContext;

public class StorageContext
{
    private readonly Dictionary<Type, object> _types;
    private readonly ConnectionParams _connectionParams;
    private readonly MessageBuilder _messageBuilder;
    private readonly JugglerSerializer _serializer;

    public StorageContext(ConnectionParams connectionParams)
    {
        _connectionParams = connectionParams;
        _types = new Dictionary<Type, object>();
        _messageBuilder = new MessageBuilder();
        _serializer = new JugglerSerializer();
    }

    public int Push()
    {
        var message = _messageBuilder.Build(_connectionParams.ConnectionString, PushDates());
        //using var connection = new JugglerConnection(_connectionParams);
        //connection.Open();
        //return connection.Send(Encoding.ASCII.GetBytes(message));
        return 1;
    }

    public int Update()
    {
        //using var connection = new JugglerConnection(_connectionParams);
        //connection.Open();
        //return connection.Send(BitConverter.GetBytes(7));
        return 1;
    }

    public JugglerList<T> Get<T>()
    {
        if(_types.ContainsKey(typeof(T)))
            return _types[typeof(T)] as JugglerList<T> ?? throw new InvalidOperationException();
        
        else
        {
            var list = new JugglerList<T>();
            _types.Add(typeof(T), list);
            return list;
        }
    }

    private List<string> PushDates()
    {
        var dates = new List<string>();
        foreach (var list in _types.Values)
            foreach (var date in (IEnumerable)list)
                dates.Add(_serializer.Serialize(date));
        return dates;
    }
} 