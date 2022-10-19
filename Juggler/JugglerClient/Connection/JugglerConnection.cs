using System.Net;
using System.Net.Sockets;

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

    public int Send(byte[] message)
    {
        _sender.Send(message);
        return _sender.Receive(Bytes);
    }
    public void Dispose()
    {
        _sender.Shutdown(SocketShutdown.Both);
        _sender.Close();
    }
}