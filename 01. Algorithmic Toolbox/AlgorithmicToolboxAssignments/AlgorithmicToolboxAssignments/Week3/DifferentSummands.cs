using System;
using System.Collections.Generic;

namespace AlgorithmicToolboxAssignments.Week3
{
    class DifferentSummands
    {
        //static void Main(string[] args)
        //{
        //    var n = int.Parse(Console.ReadLine());

        //    var c = OptimalSummands(n);

        //    Console.WriteLine(c.Count);
        //    foreach (var i in c)
        //        Console.Write(i + " ");
        //}

        private static List<int> OptimalSummands(int n)
        {
            List<int> summands = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                n -= i;
                if (n <= i)
                {
                    summands.Add(n + i);
                }
                else if (n == 0)
                {
                    summands.Add(i);
                    break;
                }
                else
                {
                    summands.Add(i);
                }
            }

            return summands;
        }
    }
}
