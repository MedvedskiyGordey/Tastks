using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class ClientProcessing
    {
        public delegate void ClientConnection(string clientName);

        public event ClientConnection ClientConnected;

        public delegate void ClientDisconnection(string clientName);

        public event ClientDisconnection ClientDisconnected;

        public delegate void MessageFromClient(string message);

        public event MessageFromClient MessageClient;

        public void Start(Stream stream)
        {
            string clientName = "";

            string message = "";

            bool status = false;

            byte[] receivedBytes = new byte[256];

            int length;

            while ((length = stream.Read(receivedBytes, 0, receivedBytes.Length)) != 0)
            {
                string receivedData = Encoding.Unicode.GetString(receivedBytes, 0, length);

                string[] words = receivedData.Split(';');

                clientName = words[0];

                message = words[1].TrimStart();

                if (status == false)
                {
                    ClientConnected.Invoke(clientName);
                    status = true;
                }

                MessageClient.Invoke(receivedData);

                ResponseToClient(stream);
            }

            ClientDisconnected.Invoke(clientName);

            status = false;
        }

        public void ResponseToClient(Stream stream)
        {
            string response = "Message delivered";

            byte[] sentBytes = Encoding.Unicode.GetBytes(response);

            stream.Write(sentBytes, 0, sentBytes.Length);
        }
    }
}
