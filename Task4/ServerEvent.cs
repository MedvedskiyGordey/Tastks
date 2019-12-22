using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public struct ClientMessage
    {
        public string ClientName { get; set; }
        
        public string Message { get; set; }
    }
    
    public class ServerEvent
    {
        List<ClientMessage> clientMessages = new List<ClientMessage>();
        
        private Server Server { get; set; }
        
        private ClientProcessing ClientProcessing { get; set; }
        
        public ServerEvent(Server server)
        {
            EventHandler(server);
        }
        
        public ServerEvent(ClientProcessing clientProcessing)
        {
            EventHandler(clientProcessing);
        }
        
        private void EventHandler(Server server)
        {
            server.MessageClient += delegate (string message)
            {
                string[] words = message.Split(new char[] { '-' });
                ClientMessage clientMessage = new ClientMessage();
                clientMessage.ClientName = words[0];
                clientMessage.Message = words[1];
                clientMessages.Add(clientMessage);
            };
        }
        
        private void EventHandler(ClientProcessing clientProcessing)
        {
            clientProcessing.MessageClient += delegate (string message)
            {
                string[] words = message.Split(';');
                ClientMessage clientMessage = new ClientMessage();
                clientMessage.ClientName = words[0];
                clientMessage.Message = words[1];
                clientMessages.Add(clientMessage);
            };
        }
       
        public List<ClientMessage> GetAllMessages()
        {
            return clientMessages;
        }

        public List<string> GetAllClientMessages(string clientName)
        {
            List<string> _clientMessages = new List<string>();
            
            foreach (var message in clientMessages)
            {
                if (message.ClientName == clientName)
                {
                    _clientMessages.Add(message.Message);
                }
            }
            
            if (_clientMessages.Count == 0)
            {
                throw new Exception("No messages found");
            }
            else
            {
                return _clientMessages;
            }
        }
    }
}
