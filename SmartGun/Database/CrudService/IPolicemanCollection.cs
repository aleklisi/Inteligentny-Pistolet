using System.Collections.Generic;
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
        Policeman Update(Policeman policeman);

        [OperationContract]
        List<Policeman> GetAll();

    }
}
