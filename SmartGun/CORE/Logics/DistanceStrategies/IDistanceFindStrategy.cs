using System.Collections.Generic;
using Database.Model;

namespace CORE.Logics.DistanceStrategies
{
    interface IDistanceFindStrategy
    {
        List<Policeman> GetClosestPolicemen(List<Policeman> policeforce, double x, double y);
    }
}