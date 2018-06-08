using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            TwoTypesOfNotation();
            //LazyLoadingIdea();
            //InfiniteColection();
            //LazyEvaluationWentWrong();
            //ForceEvaluation();
        }

        static void TwoTypesOfNotation()
        {

            var owners = TwoNotations.ForLoopOldCars();
            //var owners = TwoNotations.ForeachLoopOldCars();
            //var owners = TwoNotations.LinqQuerryNotationOldCars();
            //var owners = TwoNotations.LinqDotNotationOldCars();
            foreach (var owner in owners)
            {
                Console.WriteLine(owner);
            }
            Console.ReadKey();
        }

        static void LazyLoadingIdea()
        {
            foreach (var car in TwoNotations.Cars.Select(c => c.Age).Skip(1).Take(2).ToList())
                Console.WriteLine(car);
            Console.ReadKey();

            foreach (var car in TwoNotations.Cars.Skip(1).Take(2).Select(c => c.Age).ToList())
                Console.WriteLine(car);
            Console.ReadKey();
        }

        public static void InfiniteColection()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<int> NaturalNumbers()
        {
            int value = 0;
            for (; ; )
            {
                value++;
                yield return value;
            }
        }

        static void LazyEvaluationWentWrong()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var filter = 5;
            var filteringResult = numbers.Where(x => x > filter);
            filter = 7;
            foreach (var number in filteringResult)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }
        static void ForceEvaluation()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var filter = 5;
            var filteringResult = numbers.Where(x => x > filter).ToList();
            filter = 7;
            foreach (var i in filteringResult)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();

        }
    }
}
