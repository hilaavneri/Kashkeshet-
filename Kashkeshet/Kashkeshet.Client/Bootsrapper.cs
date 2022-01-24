using Kashkeshet.Client.Chats;
using Kashkeshet.Client.Clients;
using Kashkeshet.Client.Commands;
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
        public ChatClient Create()
        {
            TcpClient client = new TcpClient();
            client.GetStream().ReadTimeout = 1000;
            var chat = new Chat(new List<ChatMessageInfo>(), ChatTypes.Global);
            var chats = new List<Chat>();
            chats.Add(chat);
            return new ChatClient(new TcpSendRecv(client.GetStream()), new CommandFactory(), new MessagesFactory(20), chats);

        }
    }
}
