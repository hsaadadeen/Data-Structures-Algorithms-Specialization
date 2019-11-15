using System;
using System.Threading;

namespace AlgorithmicToolboxAssignments.Week2
{
    class FibonacciPartialSum
    {
        //static void Main(string[] args)
        //{
        //    //StressTest(0, 50);

        //    var l = Console.ReadLine();
        //    var n = Int64.Parse(l.Split(' ')[0]);
        //    var o = Int64.Parse(l.Split(' ')[1]);
        //    long c = GetFibonacciPartialSumLastDigit(n, o);
        //    Console.WriteLine(c);
        //}

        private static long GetFibonacciPartialSumLastDigit(long n, long o)
        {
            long l = GetPisanoPeriodHuge(n + 1) - 1;
            long k = GetPisanoPeriodHuge(o + 2) - 1;

            return (k - l + 10) % 10;
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

        private static void StressTest(int n, int o)
        {
            Random rnd = new Random();
            int ni = n;
            int oi = o;
            while (true)
            {
                n = rnd.Next(0, ni);
                o = rnd.Next(n, oi);

                Console.WriteLine("{0} {1}", n, o);
                var result1 = GetFibonacciPartialSumNaive(n, o);
                var result2 = GetFibonacciPartialSumLastDigit(n, o);
                if (result1 == result2)
                    Console.WriteLine("OK");
                else
                    Console.WriteLine("Wrong answer: {0}, {1}", result1, result2);
                Thread.Sleep(500);
            }
        }

        private static long GetFibonacciPartialSumNaive(long from, long to)
        {
            long sum = 0;

            long current = 0;
            long next = 1;

            for (long i = 0; i <= to; ++i)
            {
                if (i >= from)
                {
                    sum += current;
                }

                long new_current = next;
                next = next + current;
                current = new_current;
            }

            return sum % 10;
        }
    }
}
