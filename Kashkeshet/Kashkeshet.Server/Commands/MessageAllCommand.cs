using System;
using System.Collections.Generic;
using System.Text;

namespace Kashkeshet.Server.Commands
{
    public class MessageAllCommand : ICommand
    {
        private ClientsMsgs _messages;
        private readonly byte[] _messageToSend;

        public MessageAllCommand(ClientsMsgs messages, byte[] messageToSend)
        {
            _messages = messages;
            _messageToSend = messageToSend;
        }

        public void Run()
        {
            _messages.SendToAll(_messageToSend);
        }
    }
}
