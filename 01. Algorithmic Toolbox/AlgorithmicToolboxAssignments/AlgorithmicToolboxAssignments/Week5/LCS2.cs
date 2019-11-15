using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolboxAssignments.Week5
{
    class LCS2
    {
        //public static void Main(String[] args)
        //{
        //    var line = Console.ReadLine();
        //    int n = int.Parse(line);
        //    int[] a = new int[n];
        //    line = Console.ReadLine();
        //    for (int i = 0; i < n; i++)
        //    {
        //        a[i] = int.Parse(line.Split(' ')[i]);
        //    }
        //    line = Console.ReadLine();
        //    int m = int.Parse(line);
        //    int[] b = new int[m];
        //    line = Console.ReadLine();
        //    for (int i = 0; i < m; i++)
        //    {
        //        b[i] = int.Parse(line.Split(' ')[i]);
        //    }

        //    Console.WriteLine(LCS(a, b));
        //}

        private static int LCS(int[] a, int[] b)
        {
            int m = a.Length;
            int n = b.Length;

            int[,] L = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        L[i,j] = 0;
                    }

                    else if (a[i - 1] == b[j - 1])
                    {
                        L[i,j] = L[i - 1,j - 1] + 1;
                    }

                    else
                    {
                        L[i,j] = Math.Max(L[i - 1,j], L[i,j - 1]);
                    }
                }
            }

            return L[m,n];
        }
    }
}
