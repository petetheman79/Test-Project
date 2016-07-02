using System;
using System.Diagnostics;
using System.Linq;

namespace NextSteps
{
    static class Memiomisation
    {
        public static long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }

        static void Main()
        {
            int reps = 10;
            int its = 50000;

            Measure("baseline", reps, () =>
            {
                for (int i = 0; i < its; ++i)
                {
                    FindPrimeNumber(45);
                }
            });

            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.Collect();
              

            var memoFunc = Utils.Memoize<int, long>(FindPrimeNumber);
            Measure("memo", reps, () =>
            {
                for (int i = 0; i < its; ++i)
                {
                    memoFunc(45);
                }
            });

            Console.ReadLine();
        }

        private static void Measure(string what, int reps, Action action)
        {
            action(); //warm up

            double[] results = new double[reps];
            for (int i = 0; i < reps; ++i)
            {
                Stopwatch sw = Stopwatch.StartNew();
                action();
                results[i] = sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("{0} - AVG = {1}, MIN = {2}, MAX = {3}", 
                what, results.Average(), results.Min(), results.Max());
        }
    }
}
