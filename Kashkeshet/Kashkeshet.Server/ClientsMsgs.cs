using System;
using System.Collections.Generic;
using System.Linq;

namespace Kashkeshet.Server
{
    public class ClientsMsgs
    {
        private IDictionary<Guid, IEnumerable<byte[]>> _messages;
        private IDictionary<Guid, string> _usernames; 
        private readonly object _lock;

        public ClientsMsgs(IDictionary<Guid, IEnumerable<byte[]>> messages, IDictionary<Guid, string> usernames)
        {
            _messages = messages;
            _lock = new object();
            _usernames = usernames;
        }

        public IEnumerable<byte[]> GetMessagesByUserName(Guid id)
        {
            lock (_lock)
            {
                var msgs =  _messages[id];
                _messages[id] = new List<byte[]>();
                return msgs;
            } 
        }

        public void AddUser(Guid id, string username)
        {
            lock (_lock)
            {
                _messages[id] = new List<byte[]>();
                _usernames[id] = username;
            }

        }

        public void RemoveUser(Guid id)
        {
            _messages.Remove(id);
        }

        public void AddMessage(Guid id, byte[] msg)
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
                    item.Value.Append(msg);
                }
            }
        }

    }
}
