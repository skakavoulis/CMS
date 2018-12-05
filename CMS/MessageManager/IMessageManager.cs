using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CMS.MessageManager
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMessageManager" in both code and config file together.
    [ServiceContract]
    public interface IMessageManager
    {
        [OperationContract]
        void SendMessage(string message);
    }

}
