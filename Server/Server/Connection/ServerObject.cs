using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class ServerObject
    {
        public static TcpListener Listener;
        private readonly List<ClientObject> _clients = new List<ClientObject>();

        protected internal void AddConnection(ClientObject
            clientObject)
        {
            _clients.Add(clientObject);
        }

        protected internal void Listen(object port)
        {
            Listener = new TcpListener(IPAddress.Any, (int)port);
            Listener.Start();
            while (true)
            {
                TcpClient tcpClient = Listener.AcceptTcpClient();
                ClientObject clientObject = new ClientObject(tcpClient, this);
                Thread clientThread = new Thread(clientObject.Process);
                clientThread.Start();
            }
        }
    }
}