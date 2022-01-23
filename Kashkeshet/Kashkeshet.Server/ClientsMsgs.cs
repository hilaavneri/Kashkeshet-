using System;
using System.Collections.Generic;
using System.Linq;

namespace Kashkeshet.Server
{
    public class ClientsMsgs
    {
        private IDictionary<Guid, IEnumerable<byte[]>> _messages;        
        private object _lock;

        public ClientsMsgs(IDictionary<Guid, IEnumerable<byte[]>> messages)
        {
            _messages = messages;
            _lock = new object();
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

        public void AddUser(Guid id)
        {
            lock (_lock)
            {
                _messages[id] = new List<byte[]>(); 
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
