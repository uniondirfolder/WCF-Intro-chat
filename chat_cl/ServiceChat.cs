using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace chat_cl
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceChat" in both code and config file together.
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        public int Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect(int idClient)
        {
            throw new NotImplementedException();
        }

        public void SendInfo(string context)
        {
            throw new NotImplementedException();
        }
    }
}
