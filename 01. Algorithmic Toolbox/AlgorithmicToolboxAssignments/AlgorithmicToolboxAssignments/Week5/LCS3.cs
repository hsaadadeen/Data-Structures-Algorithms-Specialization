using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolboxAssignments.Week5
{
    class LCS3
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
        //    line = Console.ReadLine();
        //    int o = int.Parse(line);
        //    int[] c = new int[o];
        //    line = Console.ReadLine();
        //    for (int i = 0; i < o; i++)
        //    {
        //        c[i] = int.Parse(line.Split(' ')[i]);
        //    }

        //    Console.WriteLine(LCS(a, b, c));
        //}

        private static int LCS(int[] a, int[] b, int[] c)
        {
            int m = a.Length;
            int n = b.Length;
            int o = c.Length;

            int[,,] L = new int[m + 1, n + 1, o + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= o; ++k)
                    {
                        if (i == 0 || j == 0 || k == 0)
                        {
                            L[i,j,k] = 0;
                        }

                        else if (a[i - 1] == b[j - 1] && a[i - 1] == c[k - 1])
                        {
                            L[i,j,k] = L[i - 1,j - 1,k - 1] + 1;
                        }

                        else
                        {
                            L[i,j,k] = Math.Max(Math.Max(L[i - 1,j,k], L[i,j - 1,k]), L[i,j,k - 1]);
                        }
                    }
                }
            }

            return L[m,n,o];
        }

    }
}
