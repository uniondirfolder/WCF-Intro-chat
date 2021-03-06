﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace chat_cl
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceChat" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string nameClient);

        [OperationContract]
        void Disconnect(int idClient);

        [OperationContract(IsOneWay = true)]
        void SendInfo(string context, int clientId);
    }

    [ServiceContract]
    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void InfoCallback(string context);
    }
}
