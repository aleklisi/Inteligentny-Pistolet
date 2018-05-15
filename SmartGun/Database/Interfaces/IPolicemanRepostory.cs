using System.Collections.Generic;
using Database.Model;

namespace Database.Interfaces
{
    interface IPolicemanRepostory
    {
        List<Policeman> GetAll();
        int Add(Policeman policeman);
        Policeman Get(int id);
        Policeman Update(Policeman policeman, double x, double y);
        bool Delete(int id);
    }
}