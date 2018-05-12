using ObjectsManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.Interfaces
{
    public interface IPolicemanRepository
    {
        List<Policeman> GetAll();
        int Add(Policeman policeman);
        Policeman Get(int id);
        Policeman Update(Policeman artist);
        bool Delete(int id);
    }
}
