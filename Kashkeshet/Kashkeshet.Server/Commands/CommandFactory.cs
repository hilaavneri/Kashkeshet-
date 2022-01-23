using System;
using System.Collections.Generic;
using System.Text;

namespace Kashkeshet.Server.Commands
{
    public class CommandFactory
    {
        public ICommand Create(string commandName, byte[] msg, ClientsMsgs msgs, Guid id)
        {
            ICommand command = null;
            if (commandName.Equals("SNDALL"))
            {
                command = new MessageAllCommand(msgs,msg,id);
            }
            else if (commandName.Equals("SIGNIN"))
            {
                command = new SignInCommand(msgs, msg, id);
            }
            return command;
        }
    }
}
