using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Kashkeshet.Common.SendRecv
{
    class TcpSendRecv : ISendRecv
    {
        private NetworkStream _stream;

        public TcpSendRecv(NetworkStream stream)
        {
            _stream = stream;
        }

        public void CloseConnection()
        {
            _stream.Close();
        }

        public (string,int, byte[]) ReadData()
        {
            var commandLen = Encoding.ASCII.GetByteCount("AAAAAA");
            byte[] bytes = new byte[1024];           
            int bytesRec = _stream.Read(bytes, 0, bytes.Length);
            string Command = Encoding.ASCII.GetString(bytes.Take(commandLen).ToArray());            
            return (Command,bytesRec - commandLen, bytes.Skip(commandLen).ToArray());
        }

        public void WriteData(byte[] data)
        {
            _stream.Write(data, 0, data.Length);
        }
    }
}
