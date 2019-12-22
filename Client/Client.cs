using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Client
    {
        private TcpClient client;

        private NetworkStream stream;

        private MessageWork messageWork;

        int port = 8005;

        string hostName = "127.0.0.1";

        public event MessageWork.MessageFromServer MessageServer
        {
            add
            {
                messageWork.MessageServer += value;
            }
            remove
            {
                messageWork.MessageServer -= value;
            }
        }

        public string ClientName { get; private set; }

        public int Port { get; private set; }

        public string HostName { get; private set; }

        public Client(string clientName, int port, string hostName)
        {
            Port = port;
            client = new TcpClient();
            messageWork = new MessageWork();
        }

        public void Connect()
        {
            client.Connect(HostName, Port);
            stream = client.GetStream();
        }

        public void Disconnect()
        {
            stream.Close();
            client.Close();
        }

        public void SendMessage(string message)
        {
            messageWork.SendToServer(ClientName, message, stream);
        }
    }
}
