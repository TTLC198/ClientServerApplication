using System.Net.Sockets;

namespace Client
{
    public class Network
    {
        public static TcpClient client = new TcpClient("msk.vpnki.ru", 26070);
        public static NetworkStream stream;
    }
}