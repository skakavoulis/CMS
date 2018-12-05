using CMS.Services.Interfaces;
using System;

namespace CMS.Services.Messages
{
    public class MessagesService : IMessagesService
    {
        public MessagesService()
        {

        }

        public void SendMessage(string message, string recipient)
        {
            var client = new MessagesProxy.MessageManagerClient("NetNamedPipeBinding_IMessageManager");
            client.SendMessage(message);
            client.Close();
        }

        public event MessageReceivedDelegate MessageReceived;
        public void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(null, new MessageReceivedDelegateArgs { Message = message });
        }
    }
}
