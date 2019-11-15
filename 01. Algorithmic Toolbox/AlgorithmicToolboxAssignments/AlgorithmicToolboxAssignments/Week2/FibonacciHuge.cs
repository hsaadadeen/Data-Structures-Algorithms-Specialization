using System;
using System.Threading;

namespace AlgorithmicToolboxAssignments.Week2
{
    class FibonacciHuge
    {
        //static void Main(string[] args)
        //{
        //    //StressTest(10000, 100);

        //    var l = Console.ReadLine();
        //    var n = Int64.Parse(l.Split(' ')[0]);
        //    var m = Int32.Parse(l.Split(' ')[1]);
        //    long c = GetPisanoPeriodHuge(n, m);
        //    Console.WriteLine(c);
        //}

        private static long GetPisanoPeriodHuge(long n, int m)
        {
            int l = GetPisanoLength(m);

            long nc = n % l;

            return GetPisanoPeriod(nc, m);
        }

        private static int GetPisanoLength(int m)
        {
            int l = 0;

            if (m == 2) return 3;
            if (m == 3) return 8;

            int[] p = new int[m*4 + 1];
            p[0] = 0;
            p[1] = 1;
            for (int i = 1; i < m * 4; i++)
            {
                p[i + 1] = (p[i] + p[i - 1]) % m;
                if (i > 2 && p[i - 1] == 0 && p[i] == 1 && p[i + 1] == 1)
                {
                    l = i - 1;
                    break;
                }
            }

            return l == 0? p.Length - 1 : l;
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

        private static void StressTest(int n, int m)
        {
            Random rnd = new Random();
            int ni = n;
            int mi = m;
            while (true)
            {
                n = rnd.Next(1, ni);
                m = rnd.Next(2, mi);

                Console.WriteLine("{0} {1}", n, m);
                var result1 = GetPisanoPeriod(n, m);
                var result2 = GetPisanoPeriodHuge(n, m);
                if (result1 == result2)
                    Console.WriteLine("OK");
                else
                    Console.WriteLine("Wrong answer: {0}, {1}", result1, result2);
                Thread.Sleep(500);
            }
        }
    }
}
