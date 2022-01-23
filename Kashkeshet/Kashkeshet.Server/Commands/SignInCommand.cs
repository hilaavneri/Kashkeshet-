using System;
using System.Collections.Generic;
using System.Text;

namespace Kashkeshet.Server.Commands
{
    public class SignInCommand  : ICommand
    {
        private ClientsMsgs _messages;
        private readonly byte[] _messageToSend;

        public SignInCommand(ClientsMsgs messages, byte[] messageToSend)
        {
            _messages = messages;
            _messageToSend = messageToSend;
        }

        public void Run()
        {
            _messages.AddUser(Encoding.ASCII.GetString(_messageToSend));
            //Should Send here error message if already exists
        }
    }
}
