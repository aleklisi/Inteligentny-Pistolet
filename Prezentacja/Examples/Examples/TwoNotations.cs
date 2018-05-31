using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    public class TwoNotations
    {
        public static List<Car> Cars = new List<Car>
        {
            new Car("Audi","Robert",3),
            new Car("Audi","Krzysztof",5),
            new Car("Skoda","Kuba",7),
            new Car("Ferrari","Julia",1),
            new Car("Skoda","Zofia",2),
            new Car("Opel","Katarzyna",4),
            new Car("Opel","Zofia",10),
            new Car("Wolga","Aleksander",2),
        };

        public static List<string> ForLoopOldCars()
        {
            var result = new List<string>();
            for (int i = 0; i < Cars.Count; i++)
            {
                Car car = Cars[i];
                if (car.Age > 3) result.Add(car.OwnerName);
            }
            return result;
        }

        public static List<string> ForeachLoopOldCars()
        {
            var result = new List<string>();
            foreach (Car car in Cars)
            {
                if (car.Age > 3) result.Add(car.OwnerName);
            }
            return result;
        }

        public static List<string> LinqLoopOldCars()
        {
            return (from car in Cars where car.Age > 3 select car.OwnerName).ToList();
        }

        public static List<string> DotNotationOldCars()
        {
            return Cars.Where(c => c.Age > 3).Select(c => c.OwnerName).ToList();
        }
    }
}