using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task4.Translit;

namespace Task4
{
    public class ClientEvents
    {
        public string MessageServer { get; private set; }

        private MessageWork MessageProcessing { get; set; }

        private Client Client { get; set; }

        public ClientEvents(Client client)
        {
            Client = client;
            EventHandler(client);
        }

        private void EventHandler(Client client)
        {
            client.MessageServer += (message) => Transliteration.Front(message);
        }
    }
}
