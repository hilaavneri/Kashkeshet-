using Kashkeshet.Client.Chats;
using Kashkeshet.Client.Messages;
using System.Collections.Generic;

namespace Kashkeshet.Client.Commands
{
    public class CommandFactory
    {
        public ICommand Create(string command, byte[] msg, List<Chat> chats, MessagesFactory messagesFactory)
        {
            System.Console.WriteLine("in command factory "+  command);
            if (command.Equals("SNDALL"))
            {
                System.Console.WriteLine("in send all");
                return new GlobalChatMessageCommand(chats, messagesFactory.Create(msg));
            }
            return null;
        }
    }
}
