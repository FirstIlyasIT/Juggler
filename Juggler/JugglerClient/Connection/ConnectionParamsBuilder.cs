namespace JugglerClient.Connection;

public class ConnectionParamsBuilder
{
    public ConnectionParamsBuilder(string address, int port)
    {
        Address = address;
        Port = port;
    }
    
    public ConnectionParamsBuilder(string address, int port, string user, string password) : this(address, port)
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