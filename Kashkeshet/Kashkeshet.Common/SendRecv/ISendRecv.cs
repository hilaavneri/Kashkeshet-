namespace Kashkeshet.Common.SendRecv
{
    public interface ISendRecv
    {
        (int, byte[]) ReadData();
        void WriteData(byte[] data);
        void CloseConnection();
    }
}
