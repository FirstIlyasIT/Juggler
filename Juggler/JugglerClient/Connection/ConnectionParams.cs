namespace JugglerClient.Connection;

public class ConnectionParams
{
    public ConnectionParams(string address, int port)
    {
        Address = address;
        Port = port;
    }
    
    public ConnectionParams(string address, int port, string user, string password) : this(address, port)
    {
        User = user;
        Password = password;
    }

    public string Address { get; }

    public int Port { get; }
    
    private string? User { get; }

    private string? Password { get; }

    public string ConnectionString => $"user: {User ?? "not_specified"} password: {Password ?? "not_specified"}";
}