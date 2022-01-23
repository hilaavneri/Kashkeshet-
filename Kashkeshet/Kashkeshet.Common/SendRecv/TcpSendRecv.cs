using System.Net.Sockets;

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

        public (int, byte[]) ReadData()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = _stream.Read(bytes, 0, bytes.Length);
            return (bytesRec, bytes);
        }

        public void WriteData(byte[] data)
        {
            _stream.Write(data, 0, data.Length);
        }
    }
}
