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
        private List<EntityUser> clients = new List<EntityUser>();
        private int nextId = 1;
        public int Connect(string nameClient)
        {
            EntityUser client = new EntityUser(nextId, nameClient, OperationContext.Current);
            nextId++;
            SendInfo(client.Name + " connect to chat!");
            clients.Add(client);
            return client.Id;
        }

        public void Disconnect(int idClient)
        {
            var client = clients.FirstOrDefault(i => i.Id == idClient);
            if (client == null) return;
            clients.Remove(client);
            SendInfo(client.Name + " disconnect from chat!");
        }

        public void SendInfo(string context)
        {
            throw new NotImplementedException();
        }
    }
}
