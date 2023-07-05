using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using OpenTK;
using EngineClassLibrary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TanksGameLibrary.Network
{
    public class Server : GameWindow
    {
        private Map _map;

        private TcpListener _tcpListener;

        private List<TcpClient> _clientsList;

        public Server(string ip, int port)
        {
            _map = new Map(9, 16);
            _clientsList = new List<TcpClient>();
            _tcpListener = new TcpListener(IPAddress.Parse(ip), port);
            _tcpListener.Server.NoDelay = true;
        }

        public void Start()
        {
            _tcpListener.Start();

            while (_clientsList.Count < 2)
            {
                TcpClient client = _tcpListener.AcceptTcpClient();
                client.NoDelay = true;
                _clientsList.Add(client);

                TransferMap(client);
            }
            while (_clientsList[1].Available < 1) { }
            byte[] buffer = new byte[_clientsList[1].Available];
            int readBytes = _clientsList[1].GetStream().Read(buffer, 0, buffer.Length);
            string message = Encoding.UTF8.GetString(buffer, 0, readBytes);
            if (message == "ok")
                TransferData();
        }

        public void TransferMap(TcpClient client)
        {
            // serialize
            string json = JsonSerializer.Serialize(_map);
            var buffer = Encoding.UTF8.GetBytes(json);
            // send
            client.GetStream().Write(buffer, 0, buffer.Length);
        }

        public void TransferData()
        {
            var client1 = _clientsList[0].GetStream();
            var client2 = _clientsList[1].GetStream();

            byte[] buffer1;
            byte[] buffer2;

            while (true)
            {
                if (_clientsList[0].Available > 0)
                {
                    buffer1 = new byte[_clientsList[0].Available];
                    client1.Read(buffer1, 0, buffer1.Length);
                    client1.FlushAsync();
                    client2.Write(buffer1, 0, buffer1.Length);
                }
                if (_clientsList[1].Available > 0)
                {
                    buffer2 = new byte[_clientsList[1].Available];
                    client2.Read(buffer2, 0, buffer2.Length);
                    client2.FlushAsync();
                    client1.Write(buffer2, 0, buffer2.Length);
                }    
            }
        }
    }
}
