using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    public class Server
    {
        private TcpListener server;

        private ClientProcessing clientProcessing;

        public event ClientProcessing.MessageFromClient MessageClient
        {
            add
            {
                clientProcessing.MessageClient += value;
            }
            remove
            {
                clientProcessing.MessageClient -= value;
            }
        }

        public event ClientProcessing.ClientConnection ClientConnected
        {
            add
            {
                clientProcessing.ClientConnected += value;
            }
            remove
            {
                clientProcessing.ClientConnected -= value;
            }
        }

        public event ClientProcessing.ClientDisconnection ClientDisconnected
        {
            add
            {
                clientProcessing.ClientDisconnected += value;
            }
            remove
            {
                clientProcessing.ClientDisconnected -= value;
            }
        }

        public int Port { get; private set; }

        public string HostName { get; private set; }

        public delegate void ServerStarting(string message);

        public event ServerStarting ServerIsRunning;

        public delegate void ClientExceptionHandler(Exception exception);

        public event ClientExceptionHandler ClientException;

        public Server(int port = 8005, string hostName = "127.0.0.1")
        {
            Port = port;
            HostName = hostName;
            server = new TcpListener(IPAddress.Parse(HostName), Port);
            clientProcessing = new ClientProcessing();
        }

        public void StartServer()
        {
            server.Start();
            ServerIsRunning.Invoke("Waiting connections...");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                new Thread(delegate ()
                {
                    try
                    {
                        clientProcessing.Start(stream);
                        client.Close();
                    }
                    catch (Exception exception)
                    {
                        ClientException.Invoke(exception);
                    }
                }).Start();
            }
        }
    }
}
