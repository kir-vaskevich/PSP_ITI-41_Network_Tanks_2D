using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace TanksGameLibrary.Network
{
    public class Client
    {
        private TcpClient _client;

        public Client(string ip, int port)
        {
            _client = new TcpClient();
            _client.Connect(IPAddress.Parse(ip), port);
            _client.NoDelay = true;
        }

        public string GetData()
        {
            var stream = _client.GetStream();
            string json = "";
            if (_client.Available > 0)
            {
                byte[] bufferIn = new byte[_client.Available];
                int bytesRead = stream.Read(bufferIn, 0, bufferIn.Length);
                stream.FlushAsync();
                json = Encoding.UTF8.GetString(bufferIn, 0, bytesRead);
            }
            json = json.Replace("\0", "");
            return json;
        }

        public void SendData(string json)
        {
            byte[] bufferOut = Encoding.UTF8.GetBytes(json);
            _client.GetStream().Write(bufferOut, 0, bufferOut.Length);
        }

        #region Old
        //public void TransferData()
        //{
        //    var stream = _client.GetStream();
        //    while (true)
        //    {
        //        byte[] bufferOut;
        //        bufferOut = Encoding.UTF8.GetBytes(DataToSend);

        //        stream.Write(bufferOut, 0, bufferOut.Length);
        //        if (stream.DataAvailable)
        //        {
        //            byte[] bufferIn = new byte[_client.Available];
        //            int bytesRead = stream.Read(bufferIn, 0, bufferIn.Length);
        //            DataToReceive = Encoding.UTF8.GetString(bufferIn, 0, bytesRead);
        //        }
        //    }
        //}
        #endregion
    }
}
