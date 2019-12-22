using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class MessageWork
    {

        public delegate void MessageFromServer(string message);
        public event MessageFromServer MessageServer;

        public void SendToServer(string clientName, string message, Stream stream)
        {
            string sentData = clientName + ";" + message;

            byte[] sentBytes = Encoding.Unicode.GetBytes(sentData);

            stream.Write(sentBytes, 0, sentBytes.Length);

            ServerResponse(stream);
        }

        public void ServerResponse(Stream stream)
        {
            byte[] receivedBytes = new byte[256];

            int bytes = stream.Read(receivedBytes, 0, receivedBytes.Length);

            string responseData = Encoding.Unicode.GetString(receivedBytes, 0, bytes);

            MessageServer.Invoke(responseData);
        }
    }
}
