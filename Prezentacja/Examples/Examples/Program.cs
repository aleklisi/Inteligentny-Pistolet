using System;
using System.Linq;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            //TwoTypesOfNotation();
            //LazyEvaluationWentWrong();
            //ForceEvaluation();
        }

        static void TwoTypesOfNotation()
        {

            var owners = TwoNotations.ForLoopOldCars();
            //var owners = TwoNotations.ForeachLoopOldCars();
            //var owners = TwoNotations.LinqLoopOldCars();
            //var owners = TwoNotations.DotNotationOldCars();
            foreach (var owner in owners)
            {
                Console.WriteLine(owner);
            }
            Console.ReadKey();
        }

        static void LazyEvaluationWentWrong()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var filter = 5;
            var filteringResult = numbers.Where(x => x > filter);
            filter = 7;
            foreach (var i in filteringResult)
            {
                Console.WriteLine(i);
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
