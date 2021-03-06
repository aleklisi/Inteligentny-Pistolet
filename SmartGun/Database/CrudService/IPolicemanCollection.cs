﻿using System.Collections.Generic;
using System.ServiceModel;
using Database.Model;

namespace Database.CrudService
{
    [ServiceContract]
    public interface IPolicemanCollection
    {

        [OperationContract]
        int Add(Policeman policeman);

        [OperationContract]
        bool Remove(int id);

        [OperationContract]
        Policeman Update(Policeman policeman, double x, double y);

        [OperationContract]
        Policeman Update(string policemanNick, double x, double y);

        [OperationContract]
        List<Policeman> GetAll();

    }
}
