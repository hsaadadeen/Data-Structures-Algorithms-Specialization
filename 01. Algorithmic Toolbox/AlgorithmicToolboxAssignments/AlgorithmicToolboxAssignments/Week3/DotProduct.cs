using System;
using System.Collections.Generic;

namespace AlgorithmicToolboxAssignments.Week3
{
    class DotProduct
    {
        //static void Main(string[] args)
        //{
        //    var n = int.Parse(Console.ReadLine());
        //    int[] a = new int[n];
        //    var l = Console.ReadLine();
        //    var lSplit = l.Split(' ');
        //    for (int i = 0; i < lSplit.Length; i++)
        //    {
        //        a[i] = int.Parse(lSplit[i]);
        //    }

        //    int[] b = new int[n];
        //    l = Console.ReadLine();
        //    lSplit = l.Split(' ');
        //    for (int i = 0; i < lSplit.Length; i++)
        //    {
        //        b[i] = int.Parse(lSplit[i]);
        //    }

        //    var c = MaxDotProduct(a, b);

        //    Console.WriteLine(c);
        //}

        private static long MaxDotProduct(int[] a, int[] b)
        {
            Array.Sort(a, Comparer<int>.Create((x, y) => y.CompareTo(x)));
            Array.Sort(b, Comparer<int>.Create((x, y) => y.CompareTo(x)));

            long result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result += (long)a[i] * b[i];
            }
            return result;
        }
    }
}
