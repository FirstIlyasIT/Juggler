using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JugglerClient;

public class JugglerConnection : IDisposable
{
    private readonly Socket _sender;
    private readonly IPEndPoint _ipEndPoint;
    private static readonly byte[] Bytes = new byte[1024];

    public JugglerConnection(ConnectionParamsBuilder paramsBuilder)
    {
        var ipHost = Dns.GetHostEntry(paramsBuilder.Address);
        var ipAddr = ipHost.AddressList[0];
        _ipEndPoint = new IPEndPoint(ipAddr, paramsBuilder.Port);
        _sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Open()
    {
        _sender.Connect(_ipEndPoint);
    }

    public void Close()
    {
        Dispose();
    }

    public int Query(string x)
    {
        Console.WriteLine("Сокет соединяется с {0} ", _sender.RemoteEndPoint);
        byte[] msg = Encoding.UTF8.GetBytes(x);
            
        // Отправляем данные через сокет
        int bytesSent = _sender.Send(msg);
            
        // Получаем ответ от сервера
        int bytesRec = _sender.Receive(Bytes);
            
        var y = $"\nОтвет от сервера: {Encoding.UTF8.GetString(Bytes, 0, bytesRec)}\n\n";

        return 1;
    }
    public void Dispose()
    {
        _sender.Shutdown(SocketShutdown.Both);
        _sender.Close();
    }
}