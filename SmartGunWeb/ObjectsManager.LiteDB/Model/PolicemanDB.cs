using ObjectsManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.LiteDB.Model
{
    public class PolicemanDB
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public string Password { get; set; }
         public Status status { get; set; }
    }
}
