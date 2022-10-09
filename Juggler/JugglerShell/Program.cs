using System.Net;
using System.Net.Sockets;

var ipHost = Dns.GetHostEntry("localhost");
var ipAddress = ipHost.AddressList[0];
var ipEndPoint = new IPEndPoint(ipAddress, 11000);

var listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

try
{
    listener.Bind(ipEndPoint);
    listener.Listen(10);
    
    while (true)
    {
        var handler = listener.Accept();
        var msg = BitConverter.GetBytes(1);
        handler.Send(msg);
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
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