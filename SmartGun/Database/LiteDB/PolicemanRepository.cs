using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Model;
using LiteDB;

namespace Database.LiteDB
{
    public class PolicemanRepository : IPolicemanRepostory
    {
        private readonly string _policemanConnection = DatabaseConnections.PolicemanConnection;

        public List<Policeman> GetAll()
        {
            using (var db = new LiteDatabase(_policemanConnection))
            {
                var repository = db.GetCollection<Policeman>("policeman");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public int Add(Policeman policeman)
        {
            using (var db = new LiteDatabase(_policemanConnection))
            {
                var dbObject = policeman;

                var repository = db.GetCollection<Policeman>("policeman");
                if (repository.FindById(policeman.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Policeman Get(int id)
        {
            using (var db = new LiteDatabase(_policemanConnection))
            {
                var repository = db.GetCollection<Policeman>("policeman");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Policeman Update(Policeman policeman,double x, double y)
        {
            using (var db = new LiteDatabase(_policemanConnection))
            {
                
                policeman.X = x;
                policeman.Y = y;
                
                var repository = db.GetCollection<Policeman>("policeman");
                if (repository.Update(policeman))
                {
                    return policeman;
                }
                return  null;
            }
        }

        public Policeman Update(string policemanNick, double x, double y)
        {
            using (var db = new LiteDatabase(_policemanConnection))
            {

                var repository = db.GetCollection<Policeman>("policeman");
                if (!repository.Exists(pol => pol.Nick == policemanNick))
                {
                    return null;
                }
                var policeman = repository.Find(pol => pol.Nick == policemanNick).First();
                
                policeman.X = x;
                policeman.Y = y;

                if (repository.Update(policeman))
                {
                    return policeman;
                }
                return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(_policemanConnection))
            {
                var repository = db.GetCollection<Policeman>("policeman");
                return repository.Delete(id);
            }
        }
    }
}