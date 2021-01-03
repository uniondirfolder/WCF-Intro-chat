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
        private List<EntityUser> _clients = new();
        private int _nextId = 1;
        public int Connect(string nameClient)
        {
            EntityUser client = new EntityUser(_nextId, nameClient, OperationContext.Current);
            _nextId++;
            SendInfo(": " + client.Name + " connect to chat!", 0);
            _clients.Add(client);
            return client.Id;
        }

        public void Disconnect(int idClient)
        {
            var client = _clients.FirstOrDefault(i => i.Id == idClient);
            if (client == null) return;
            _clients.Remove(client);
            SendInfo(": " + client.Name + " disconnect from chat!", 0);
        }

        public void SendInfo(string context, int clientId)
        {
            foreach (var client in _clients)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = _clients.FirstOrDefault(i => i.Id == clientId);//если кон. или диск. сообщ уже готово
                if (user != null)
                {
                    answer += ": " + user.Name + " ";
                }

                answer += context;
                client.OperationContext.GetCallbackChannel<IServerChatCallback>().InfoCallback(answer);
            }
        }
    }
}
