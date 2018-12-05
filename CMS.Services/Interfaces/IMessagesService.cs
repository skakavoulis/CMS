using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Interfaces
{
   public interface IMessagesService
   {
       void SendMessage(string s, string recipient);
       event MessageReceivedDelegate MessageReceived;
       void OnMessageReceived(string message);
   }

    public delegate void MessageReceivedDelegate(object sender, MessageReceivedDelegateArgs args);

    public class MessageReceivedDelegateArgs
    {
        public string Message { get; set; }
    }
}
