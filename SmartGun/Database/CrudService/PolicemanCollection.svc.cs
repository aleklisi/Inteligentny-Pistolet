using System.Collections.Generic;
using System.ServiceModel;
using Database.Interfaces;
using Database.LiteDB;
using Database.Model;

namespace Database.CrudService{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PolicemanCollection : IPolicemanCollection
    {
        private readonly IPolicemanRepostory _policemansRepostiry;

        PolicemanCollection()
        {
            _policemansRepostiry = new PolicemanRepository();
        }

        public int Add(Policeman policeman)
        {
            return _policemansRepostiry.Add(policeman);
        }

        public bool Remove(int id)
        {
            return _policemansRepostiry.Delete(id);
        }

        public Policeman Update(Policeman policeman)
        {
            return _policemansRepostiry.Update(policeman);
        }

        public List<Policeman> GetAll()
        {
            return _policemansRepostiry.GetAll();
        }
    }
}
