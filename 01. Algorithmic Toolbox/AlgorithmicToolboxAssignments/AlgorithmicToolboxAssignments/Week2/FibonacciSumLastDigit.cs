using System;
using System.Threading;

namespace AlgorithmicToolboxAssignments.Week2
{
    class FibonacciSumLastDigit
    {
        //static void Main(string[] args)
        //{
        //    //StressTest(500);

        //    var n = Int64.Parse(Console.ReadLine());
        //    long c = GetFibonacciSumLastDigit(n);
        //    Console.WriteLine(c);
        //}

        private static long GetFibonacciSumLastDigit(long n)
        {
            long l = GetPisanoPeriodHuge(n + 2);

            return (l + 9) % 10;
        }

        private static long GetPisanoPeriodHuge(long n, int m = 10)
        {
            int l = GetPisanoLength(m);

            long nc = n % l;

            return GetPisanoPeriod(nc, m);
        }

        private static int GetPisanoLength(int m)
        {
            int l = 0;
            int size = m * 6;

            if (m == 2) return 3;
            if (m == 3) return 8;

            int[] p = new int[size + 1];
            p[0] = 0;
            p[1] = 1;
            for (int i = 1; i < size; i++)
            {
                p[i + 1] = (p[i] + p[i - 1]) % m;
                if (i > 2 && p[i - 1] == 0 && p[i] == 1 && p[i + 1] == 1)
                {
                    l = i - 1;
                    break;
                }
            }

            return l == 0 ? p.Length - 1 : l;
        }

        private static long GetPisanoPeriod(long n, long m)
        {
            if (n < 2)
                return n % m;

            long[] p = new long[n + 1];
            p[0] = 0;
            p[1] = 1;
            for (long i = 1; i < n; i++)
                p[i + 1] = (p[i] + p[i - 1]) % m;

            return p[n];
        }

        private static void StressTest(int n)
        {
            Random rnd = new Random();
            int ni = n;
            while (true)
            {
                n = rnd.Next(1, ni);

                Console.WriteLine("{0}", n);
                var result1 = GetFibonacciSumNaive(n);
                var result2 = GetFibonacciSumLastDigit(n);
                if (result1 == result2)
                    Console.WriteLine("OK");
                else
                    Console.WriteLine("Wrong answer: {0}, {1}", result1, result2);
                Thread.Sleep(500);
            }
        }

        private static long GetFibonacciSumNaive(long n)
        {
            if (n <= 1)
                return n;

            long previous = 0;
            long current = 1;
            long sum = 1;

            for (long i = 0; i < n - 1; ++i)
            {
                long tmp_previous = previous;
                previous = current;
                current = tmp_previous + current;
                sum += current;
            }

            return sum % 10;
        }

    }
}
