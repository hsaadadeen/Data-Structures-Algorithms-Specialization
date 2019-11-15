using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AlgorithmicToolboxAssignments.Week3
{
    class FractionalKnapsack
    {
        //static void Main(string[] args)
        //{
        //    var l = Console.ReadLine();
        //    var n = int.Parse(l.Split(' ')[0]);
        //    var capacity = int.Parse(l.Split(' ')[1]);
        //    int[] values = new int[n];
        //    int[] weights = new int[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        l = Console.ReadLine();
        //        values[i] = int.Parse(l.Split(' ')[0]);
        //        weights[i] = int.Parse(l.Split(' ')[1]);
        //    }

        //    var c = GetOptimalValue(capacity, values, weights);

        //    Console.WriteLine("{0:F4}", c);
        //}

        private static double GetOptimalValue(int capacity, int[] values, int[] weights)
        {
            double value = 0;
            double[] valuePerUint = new double[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                valuePerUint[i] = (double)values[i] / weights[i];
            }

            Array.Sort(valuePerUint, weights, Comparer<double>.Create((x, y) => y.CompareTo(x)));

            int j = 0;
            while (capacity > 0 && j < weights.Length)
            {
                int a = weights[j] > capacity ? capacity : weights[j];
                value += (a * valuePerUint[j]);
                weights[j] -= a;
                capacity -= a;

                j++;
            }

            return value;
        }
    }
}
