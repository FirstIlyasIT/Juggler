using System.Net;
using System.Net.Sockets;
using System.Text;

var ipHost = Dns.GetHostEntry("localhost");
var ipAddress = ipHost.AddressList[0];
var ipEndPoint = new IPEndPoint(ipAddress, 11000);
var bytes = new byte[1024];
var cash = string.Empty;

var listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

try
{
    listener.Bind(ipEndPoint);
    listener.Listen(10);
    
    while (true)
    {
        Console.WriteLine($"Ожидаем соединение через порт {ipEndPoint}");
        var handler = listener.Accept();
        var rec = handler.Receive(bytes);
        var msg = Encoding.UTF8.GetString(bytes, 0, rec);
        Console.Write("Полученно сообщение: " + msg + "\n");
        if (msg == "get")
        {
            Console.WriteLine("Получен запрос на обновление");
            bytes = Encoding.UTF8.GetBytes(cash);
            handler.Send(bytes);
            Console.WriteLine("сообщение отправлено обратно");
        }
        else
        {
            cash = msg.Substring(msg.IndexOf(">", StringComparison.Ordinal));
            handler.Send(Encoding.UTF8.GetBytes("Ok"));
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.ReadLine();
}