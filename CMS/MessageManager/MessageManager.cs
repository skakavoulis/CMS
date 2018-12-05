using CMS.Services.Interfaces;
using System;
using System.ServiceModel;

namespace CMS.MessageManager
{
    [ServiceBehavior(UseSynchronizationContext = false)]
    public class MessageManager : IMessageManager
    {
        private IMessagesService _msg;
        public MessageManager()
        {
            _msg = App.MessagesFactory.InstatiateService();
        }

        public void SendMessage(string message)
        {
            _msg.OnMessageReceived(message);
        }
    }
}
