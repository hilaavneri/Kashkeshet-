using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kashkeshet.Server.Commands
{
    public class MessageAllCommand : ICommand
    {
        private ClientsMsgs _messages;
        private readonly byte[] _messageToSend;
        private readonly int _id; 

        public MessageAllCommand(ClientsMsgs messages, byte[] messageToSend, int id)
        {
            _messages = messages;
            _messageToSend = messageToSend;
            _id = id;
        }

        public void Run()
        {
            var toSend = (Encoding.ASCII.GetBytes("SNDALL" + _messages.GetUserNameById(_id).PadRight(20))).Concat(_messageToSend).ToArray();
            _messages.SendToAll(toSend);
        }
    }
}
