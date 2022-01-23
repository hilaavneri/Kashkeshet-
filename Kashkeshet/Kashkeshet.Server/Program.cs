using Kashkeshet.Server.ClientHandlers;
using Kashkeshet.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Kashkeshet.Server.Commands;

namespace Kashkeshet.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            var server = new TcpListener(localAddr, 5500);
            ClientsListener tl = new ClientsListener(server);
            var msgs = new ClientsMsgs(new Dictionary<Guid, List<byte[]>>(), new Dictionary<Guid, string>());
            tl.AcceptClients(new ClientHandler(msgs, new CommandFactory()));
        }
    }
}
