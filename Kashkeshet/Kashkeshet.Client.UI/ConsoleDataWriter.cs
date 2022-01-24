using Client.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;

namespace Client.UI
{
    public class ConsoleDataWriter : IWriter
    {
        private ConcurrentQueue<byte[]> _messages;

        public ConsoleDataWriter(ConcurrentQueue<byte[]> messages)
        {
            _messages = messages;
        }

        public byte[] GetData()
        {
            byte[] msg = null;   
             _messages.TryDequeue(out msg);

            return msg;
        }
        
        public void AddMsg(byte[] msg)
        {
            _messages.Enqueue(msg);
        }
    }
}
