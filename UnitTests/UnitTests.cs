using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;
using static Task4.Translit;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod()]
        public void SendMessage()
        {
            string clientName = "Qwerty234";
            string message = "MessageMessage";

            MemoryStream memoryStream = new MemoryStream();
            MessageWork messageProcessing = new MessageWork();
            messageProcessing.SendToServer(clientName, message, memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            byte[] sentBytes = new byte[256];

            int bytes = memoryStream.Read(sentBytes, 0, sentBytes.Length);

            string sentMessage = Encoding.Unicode.GetString(sentBytes, 0, bytes);

            Assert.IsTrue(sentMessage == "Qwerty234;MessageMessage");
        }

        [TestMethod()]
        public void RecieveMessage()
        {
            string recieveMessage = "Qwerty234;MessageMessage";
            string clientName = "";
            string clientMessage = "";
            MemoryStream memoryStream = new MemoryStream();
            ClientProcessing clientProcessing = new ClientProcessing();
            clientProcessing.ClientConnected += (message) => clientName = message;
            clientProcessing.MessageClient += delegate (string message)
            {
                clientMessage = message;
            };
            byte[] recievedBytes = Encoding.Unicode.GetBytes(recieveMessage);
            memoryStream.Write(recievedBytes, 0, recievedBytes.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            clientProcessing.Start(memoryStream);
            Assert.IsTrue(clientName == "Qwerty234" && clientMessage == "Qwerty234;MessageMessage");
            memoryStream.Close();
        }

        [TestMethod()]
        public void TransliterationTest()
        {
            string message = "Привет мир";
            string messageT = Transliteration.Front(message);
            Assert.IsTrue(messageT == "Privet mir");
        }
    }
}
