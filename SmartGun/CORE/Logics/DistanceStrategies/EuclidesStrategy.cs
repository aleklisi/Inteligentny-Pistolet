using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Database.Model;

namespace CORE.Logics.DistanceStrategies
{
    class EuclidesStrategy :IDistanceFindStrategy
    {
        public List<Policeman> GetClosestPolicemen(List<Policeman> policeforce, double x, double y)
        {
            return policeforce.OrderBy(p => (p.X - x) * (p.X - x) + (p.Y - y) * (p.Y - y)).Distinct().Take(3).ToList();
            
        }
    }
}