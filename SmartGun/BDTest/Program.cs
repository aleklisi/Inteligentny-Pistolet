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

        static Policeman AssignPosition(Policeman policeman, double x, double y)
        {
            policeman.X = x;
            policeman.Y = y;
            return policeman;
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
                new Policeman("Eane", "E"),
                new Policeman("Fane", "F"),
                new Policeman("Gane", "G"),
                new Policeman("Hane", "H"),
                new Policeman("Iane", "I"),
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    policemans[i * 3 + j].X = j+1;
                    policemans[i * 3 + j].Y = i+1;

                }
            }

            Console.WriteLine("Before Adding");
            PrintDb(client);

            foreach (var policeman in policemans)
            {
                policeman.Id = client.Add(policeman);
            }

            PrintDb(client);
            Console.ReadKey();
        }
    }
}
