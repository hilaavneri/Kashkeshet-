using System.Collections.Generic;
using System.Linq;

namespace Kashkeshet.Server
{
    public class ClientsMsgs
    {
        private IDictionary<string, IEnumerable<byte[]>> _messages;        
        private object _lock;

        public ClientsMsgs(IDictionary<string, IEnumerable<byte[]>> messages)
        {
            _messages = messages;
            _lock = new object();
        }

        public IEnumerable<byte[]> GetMessagesByUserName(string username)
        {
            lock (_lock)
            {
                var msgs =  _messages[username];
                _messages[username] = new List<byte[]>();
                return msgs;
            } 
        }

        public void AddUser(string username)
        {
            lock (_lock)
            {
                _messages[username] = new List<byte[]>(); 
            }

        }

        public void RemoveUser(string username)
        {
            _messages.Remove(username);
        }

        public void AddMessage(string username, byte[] msg)
        {
            lock (_lock)
            {
                _messages[username].Append(msg);
            }
        }

        public void SendToAll(byte[] msg)
        {
            lock (_lock)
            {
                foreach (var item in _messages)
                {
                    item.Value.Append(msg);
                }
            }
        }

    }
}
