using Kashkeshet.Client.Common;
using System;
using System.Text;

namespace Kashkeshet.Client.UI
{
    public class ConsoleDataWriter : IWriter
    {
        public byte[] GetData()
        {
            string data = Console.ReadLine();
            return Encoding.ASCII.GetBytes(data);
        }
    }
}
