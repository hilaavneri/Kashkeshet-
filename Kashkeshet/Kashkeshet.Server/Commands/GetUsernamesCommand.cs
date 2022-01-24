using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kashkeshet.Server.Commands
{
    class GetUsernamesCommand : ICommand
    {
        private readonly string _name;
        private ClientsMsgs _messages;
        private readonly int _id;

        public void Run()
        {
            string usernames = "";
            _messages.GetAllUserNames().ForEach(username => usernames += username + "|");
            var toSend = Encoding.ASCII.GetBytes(_name).Concat(Encoding.ASCII.GetBytes(usernames)).ToArray();
            _messages.SendMessageById(_id, toSend);
        }
    }
}
