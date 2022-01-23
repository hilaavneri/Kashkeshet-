using Kashkeshet.Server.ClientHandlers;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Kashkeshet.Server
{
    public class ClientsListener
    {
        private TcpListener _server;
        private readonly int _port;

        public ClientsListener(int port)
        {
            _port = port;
        }

        public void AcceptClients(IClientHandler clientHandler)
        {
            while (true)
            {
                Console.Write("Waiting for a connection... ");
                TcpClient client = _server.AcceptTcpClient();
                Task.Run(() => clientHandler.HandleClient());
            }

        }

        public void Connect()
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                _server = new TcpListener(localAddr, _port);
                _server.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
