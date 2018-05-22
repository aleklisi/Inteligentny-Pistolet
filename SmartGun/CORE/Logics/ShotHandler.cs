using System;
using System.Collections.Generic;
using CORE.Interfaces;
using CORE.Logics.DistanceStrategies;
using Database.CrudService;
using Database.Model;
using MessagesLibrary;
using PointOfContact;

namespace CORE.Logics
{
    internal class ShotHandler : IShotHandler
    {
        public void Handle(ShotMessage message)
        {
            IDistanceFindStrategy strategy = new EuclidesStrategy();
            var closestPoliceman = GetClosetPoliceman(message.X, message.Y,strategy);
            var closestNeighbours = closestPoliceman.FindAll(policeman => policeman.X != message.X && policeman.Y != message.Y);
            AddWarningToDispatcher(closestNeighbours, message);

        }
        private List<Policeman> GetClosetPoliceman(double x, double y,IDistanceFindStrategy strategy)
        {
            IPolicemanCollection client = new PolicemanCollection();
            List<Policeman> policeforce = new List<Policeman>(client.GetAll().ToArray());

            return strategy.GetClosestPolicemen(policeforce, x, y);
        }

        private void AddWarningToDispatcher(List<Policeman> policemen, ShotMessage message)
        {
            HTMLTableService.AddColumn(message);

            foreach (var policeman in policemen)
            {
                Console.WriteLine(policeman.Name);
      
                HTMLTableService.AddColumn(new UpdateMessage(policeman.X, policeman.Y, policeman.Name));
            }

        }
    }
}