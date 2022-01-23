namespace Kashkeshet.Common.SendRecv
{
    public interface ISendRecv
    {
        (string,int, byte[]) ReadData();
        void WriteData(byte[] data);
        void CloseConnection();
    }
}
