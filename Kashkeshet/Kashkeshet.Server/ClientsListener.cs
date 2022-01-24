using Kashkeshet.Server.ClientHandlers;
using Kashkeshet.Common.SendRecv;

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Kashkeshet.Server.Commands;

namespace Kashkeshet.Server
{
    public class ClientsListener
    {
        private TcpListener _server;
        //private readonly int _port;

        public ClientsListener(TcpListener server)
        {
            _server = server;
        }

        public void AcceptClients(ClientsMsgs msgs, CommandFactory commandFactory )
        {
            _server.Start();
            Console.Write("Waiting for a connection... ");
            int i = 0;
            while (true)
            {
                TcpClient client = _server.AcceptTcpClient();
                client.GetStream().ReadTimeout = 1000;
                var clientHandler = new ClientHandler(msgs, commandFactory);
                Task.Run(() => clientHandler.HandleClient(i, new TcpSendRecv(client.GetStream())));
                i++;

            }

        }

        //public void Connect()
        //{
        //    try
        //    {
        //        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        //        _server = new TcpListener(localAddr, _port);
        //        _server.Start();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //}
    }
}
