using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kashkeshet.Server
{
    public class ClientsMsgs
    {
        private IDictionary<int, List<byte[]>> _messages;
        private IDictionary<int, string> _usernames; 
        private readonly object _lock;

        public ClientsMsgs(IDictionary<int, List<byte[]>> messages, IDictionary<int, string> usernames)
        {
            _messages = messages;
            _lock = new object();
            _usernames = usernames;
        }

        public bool IsClientSignedIn(int id)
        {
            lock (_lock)
            {
                return _messages.ContainsKey(id);
            }
        }

        public List<byte[]> GetMessagesById(int id)
        {
            lock (_lock)
            {
                List<byte[]> msgs =  new List<byte[]>(_messages[id]);
                if (msgs.Count>0)
                {
                    foreach (var item in msgs)
                    {
                        Console.WriteLine("message: "+ Encoding.ASCII.GetString(item));
                    }
                }
                _messages[id] = new List<byte[]>();
                return msgs;
            } 
        }

        public void AddUser(int id, string username)
        {
            lock (_lock)
            {
                Console.WriteLine($"Adding user name, key:{id}, user name: {username}"); 
                _messages[id] = new List<byte[]>();
                _usernames[id] = username;
            }

        }

        public void RemoveUser(int id)
        {
            _messages.Remove(id);
        }

        public void AddMessage(int id, byte[] msg)
        {
            lock (_lock)
            {
                _messages[id].Append(msg);
            }
        }

        public void SendToAll(byte[] msg)
        {
         
            lock (_lock)
            {
                foreach (var item in _messages)
                {
                    Console.WriteLine("key:" + item.Key);
                    Console.WriteLine("username:" + _usernames[item.Key]);
                    Console.WriteLine(Encoding.ASCII.GetString(msg));
                    item.Value.Add(msg);
                    Console.WriteLine("COUNT:" + item.Value.Count);
                }
            }
        }

    }
}
