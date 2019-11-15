using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmicToolboxAssignments.Week3
{
    class LargestNumber
    {
        //static void Main(string[] args)
        //{
        //    var n = int.Parse(Console.ReadLine());
        //    var l = Console.ReadLine();
        //    var a = l.Split(' ');

        //    var c = GetLargestNumber(a);

        //    Console.WriteLine(c);
        //}

        private static string GetLargestNumber(string[] a)
        {
            Array.Sort(a, Comparer<string>.Create((x, y) => String.Compare(y + x, x + y, StringComparison.Ordinal)));

            return a.Aggregate("", (current, t) => current + t);
        }
    }
}
