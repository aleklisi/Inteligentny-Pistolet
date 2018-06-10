using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class NaturalNambers
    {

        public static void NaturalNumbersHowToLazyLoading()
        {
            var numbers = NaturalNumbersInstantLoading().
            //var numbers = NaturalNumbersLazyLoading().
                SkipWhile(x => x < 7).Where(x => x % 2 == 0).Take(5).ToList();
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }

        private static IEnumerable<int> NaturalNumbersInstantLoading()
        {
            var result = new List<int>();
            int value = 0;

            for (;;)
            {
                value++;
                result.Add(value);
            }

            return result;
        }

        private static IEnumerable<int> NaturalNumbersLazyLoading()
        {
            int value = 0;
            for (;;)
            {
                value++;
                yield return value;
            }
        }

        public static void GeneratePrimes()
        {
            var primes = PrimeNumbersInRange(10000).
                SkipWhile(x => x < 2000).
                TakeWhile(x => x < 2100);

            foreach (var prime in primes)
            {
            Console.WriteLine(prime);
            }
            Console.ReadKey();
        }

        public static void ParallelTheEasyWay()
        {
            PrimeNumbersInRange(10);
            var watchSingleThread = System.Diagnostics.Stopwatch.StartNew();
            PrimeNumbersInRange(1000 * 1000 * 1000);
            watchSingleThread.Stop();
            Console.WriteLine($"Ordynary execution: {watchSingleThread.Elapsed}");

            PrimeNumbersInRangeAsParallel(10);
            var watchForParallel = System.Diagnostics.Stopwatch.StartNew();
            PrimeNumbersInRangeAsParallel(1000 * 1000 * 1000);
            watchForParallel.Stop();
            Console.WriteLine($"Parallel execution: {watchForParallel.Elapsed}");
            Console.ReadKey();
        }
        private static IEnumerable<int> PrimeNumbersInRange(int rangeTopLimit)
        {
            return Enumerable.Range(2, rangeTopLimit)
                .Where(number =>
                    Enumerable.Range(2, (int)Math.Sqrt(number) - 1)
                        .All(divisor => number % divisor != 0));

        }
        private static IEnumerable<int> PrimeNumbersInRangeAsParallel(int rangeTopLimit)
        {
            return Enumerable.Range(2, rangeTopLimit)
                .AsParallel()
                .Where(number =>
                    Enumerable.Range(2, (int)Math.Sqrt(number) - 1)
                        .All(divisor => number % divisor != 0));

        }
    }
}