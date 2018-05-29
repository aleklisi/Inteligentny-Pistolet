using System.Collections.Generic;
using CORE.Interfaces;
using CORE.Logics.DistanceStrategies;
using Database.CrudService;
using Database.Model;
using MessagesLibrary;

namespace CORE.Logics
{
    internal class ShotHandler : IShotHandler
    {
        public void Handle(ShotMessage message)
        {
            IDistanceFindStrategy strategy = new EuclidesStrategy();
            var closestPoliceman = GetClosetPoliceman(message.X, message.Y,strategy);
            closestPoliceman.RemoveAll(policeman => policeman.Name == message.Username);
            if (closestPoliceman.Count > 2)
            {
                closestPoliceman.RemoveAt(2);
            }

            AddWarningToDispatcher(closestPoliceman, message);

        }
        private List<Policeman> GetClosetPoliceman(double x, double y,IDistanceFindStrategy strategy)
        {
            IPolicemanCollection client = new PolicemanCollection();
            List<Policeman> policeforce = new List<Policeman>(client.GetAll().ToArray());

            return strategy.GetClosestPolicemen(policeforce, x, y);
        }

        private void AddWarningToDispatcher(List<Policeman> policemen, ShotMessage message)
        {
            HTMLTableGenerator.AddRow(message, policemen);
        }
    }
}