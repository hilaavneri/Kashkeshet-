using Kashkeshet.Client.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kashkeshet.Client.Messages
{
    public class MessagesFactory
    {
        private int _userNameLength;

        public MessagesFactory(int userNameLength)
        {
            _userNameLength = userNameLength;
        }

        public ChatMessageInfo Create(byte[] data)
        {
            Console.WriteLine("got"+ Encoding.ASCII.GetString(data));
            string username = Encoding.ASCII.GetString(data.Take(_userNameLength).ToArray());
            Console.WriteLine("user" + username);
            return new ChatMessageInfo(ChatTypes.Global, username, data.Skip(_userNameLength).ToArray());
        }
    }
}
