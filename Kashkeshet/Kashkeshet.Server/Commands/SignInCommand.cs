﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kashkeshet.Server.Commands
{
    public class SignInCommand  : ICommand
    {
        private ClientsMsgs _messages;
        private readonly byte[] _username;
        private readonly Guid _id;

        public SignInCommand(ClientsMsgs messages, byte[] messageToSend, Guid id)
        {
            _messages = messages;
            _username = messageToSend;
            _id = id;
        }

        public void Run()
        {
            _messages.AddUser(_id,Encoding.ASCII.GetString(_username));
            //Should Send here error message if already exists
        }
    }
}
