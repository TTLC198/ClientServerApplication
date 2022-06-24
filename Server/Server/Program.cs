using System.Threading;

namespace Server
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServerObject serverObject = new ServerObject();
            Thread listenThread = null;
            new Thread(serverObject.Listen).Start(8888);
        }
    }
}