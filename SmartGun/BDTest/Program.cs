using System;
using Database.CrudService;
using Database.Model;

namespace BDTest
{
    class Program
    {
        static void PrintDb(IPolicemanCollection client)
        {
            var all = client.GetAll();

            foreach (var p in all)
            {
                Console.WriteLine(" " + p.Id + " " + p.Name + " " + p.Nick + " " + p.X + " " + p.Y);
            }

        }
        static void Main()
        {
            var client = new PolicemanCollection();
            Console.WriteLine("Initial Status");
            PrintDb(client);

            var policemans = new[]
            {
                new Policeman("Aane", "A"),
                new Policeman("Bane", "B"),
                new Policeman("Cane", "C"),
                new Policeman("Dane", "D"),
            };

            Console.WriteLine("Before Adding");
            PrintDb(client);

            foreach (var policeman in policemans)
            {
                policeman.Id = client.Add(policeman);
                Console.WriteLine("Policeman added");
                PrintDb(client);
            }

            Console.WriteLine("Policeman before RM");
            PrintDb(client);

            client.Remove(1);

            Console.WriteLine("Policeman After RM");
            PrintDb(client);

            Console.WriteLine("Policeman before Update");
            PrintDb(client);

            client.Update(policemans[1], 2.0, 2.0);

            Console.WriteLine("Policeman After Update");
            PrintDb(client);
            Console.WriteLine("Policeman before Update by nick ");
            PrintDb(client);

            client.Update("A", 2.0, 2.0);

            Console.WriteLine("Policeman After Update");
            PrintDb(client);
            Console.ReadKey();
        }
    }
}
