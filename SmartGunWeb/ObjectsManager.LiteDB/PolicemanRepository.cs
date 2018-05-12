using ObjectsManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class PolicemanRepository : IPolicemanRepository
    {
        private readonly string _policemanConnection = DatabaseConnection.PolicemanConnection;

        public List<Policeman> GetAll()
        {
            using (var db = new LiteDatabase(this._policemanConnection))
            {
                var repository = db.GetCollection<Model.PolicemanDB>("policemans");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Policeman policeman)
        {
            using (var db = new LiteDatabase(this._policemanConnection))
            {
                var dbObject = InverseMap(policeman);

                var repository = db.GetCollection<PolicemanDB>("policemans");
                if (repository.FindById(policeman.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Policeman Get(int id)
        {
            using (var db = new LiteDatabase(this._policemanConnection))
            {
                var repository = db.GetCollection<PolicemanDB>("policemans");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Policeman Update(Policeman artist)
        {
            using (var db = new LiteDatabase(this._policemanConnection))
            {
                var dbObject = InverseMap(artist);

                var repository = db.GetCollection<PolicemanDB>("policemans");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._policemanConnection))
            {
                var repository = db.GetCollection<PolicemanDB>("policemans");
                return repository.Delete(id);
            }
        }

        internal Policeman Map(PolicemanDB dbPoliceman)
        {
            if (dbPoliceman == null)
                return null;
            return new Policeman() {  Id = dbPoliceman.Id, Name = dbPoliceman.Name, Password = dbPoliceman.Password};
        }

        internal PolicemanDB InverseMap(Policeman policeman)
        {
            if (policeman == null)
                return null;
            return new PolicemanDB() { Id = policeman.Id, Name = policeman.Name, Password = policeman.Password };
        }
    }
}
