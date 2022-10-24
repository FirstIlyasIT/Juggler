using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JugglerClient.Connection;

public class JugglerConnection : IDisposable
{
    private readonly Socket _sender;
    private readonly IPEndPoint _ipEndPoint;
    private static readonly byte[] Bytes = new byte[1024];

    public JugglerConnection(ConnectionParams @params)
    {
        var ipHost = Dns.GetHostEntry(@params.Address);
        var ipAddress = ipHost.AddressList[0];
        _ipEndPoint = new IPEndPoint(ipAddress, @params.Port);
        _sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Open()
    {
        _sender.Connect(_ipEndPoint);
    }

    public void Close()
    {
        Dispose();
    }

    public string Send(byte[] message)
    {
        _sender.Send(message);
        var answer = new byte[1024];
        do
        {
            _sender.Receive(answer);
        } while (answer.All(x => x == 0));
        
        return Encoding.UTF8.GetString(answer);
    }
    public void Dispose()
    {
        _sender.Shutdown(SocketShutdown.Both);
        _sender.Close();
    }
}