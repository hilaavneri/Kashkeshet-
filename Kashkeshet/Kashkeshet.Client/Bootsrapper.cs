using Kashkeshet.Client.Chats;
using Kashkeshet.Client.Clients;
using Kashkeshet.Client.Commands;
using Client.Common;
using Kashkeshet.Client.Messages;
using Kashkeshet.Common.SendRecv;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Kashkeshet.Client
{
    public class Bootsrapper
    {
        public ChatClient Create(IWriter writer, List<Chat> chats,string ip, int port)
        {
            TcpClient client = new TcpClient(ip, port);
            client.GetStream().ReadTimeout = 1000;
  
            return new ChatClient(new TcpSendRecv(client.GetStream()), new CommandFactory(), new MessagesFactory(20), chats,writer);

        }
    }
}
