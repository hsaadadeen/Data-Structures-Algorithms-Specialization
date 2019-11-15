using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolboxAssignments.Week6
{
    class Knapsack
    {
        //static void Main(string[] args)
        //{
        //    var l = Console.ReadLine();
        //    var W = int.Parse(l.Split(' ')[0]);
        //    var n = int.Parse(l.Split(' ')[1]);
        //    int[] w = new int[n];
        //    l = Console.ReadLine();
        //    for (int i = 0; i < n; i++)
        //    {
        //        w[i] = int.Parse(l.Split(' ')[i]);
        //    }

        //    Console.WriteLine(OptimalWeight(W, w));
        //}


        private static int OptimalWeight(int W, int[] w)
        {
            int[,] K = new int[w.Length + 1, W + 1];

            for (int i = 0; i <= w.Length; ++i)
            {
                for (int j = 0; j <= W; ++j)
                {
                    if (i == 0 || j == 0)
                    {
                        K[i,j] = 0;
                    }
                    else if (w[i - 1] <= j)
                    {
                        K[i,j] = Math.Max(K[i - 1,j], w[i - 1] + K[i - 1,j - w[i - 1]]);
                    }
                    else
                    {
                        K[i,j] = K[i - 1,j];
                    }
                }
            }
            return K[w.Length,W];
        }
    }
}
