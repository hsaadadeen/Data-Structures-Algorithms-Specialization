using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolboxAssignments.Week6
{
    class Partition3
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            var l = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(l.Split(' ')[i]);
            }

            Console.WriteLine(Partition(a));
        }

        private static int Partition(int[] A)
        {
            int sum = A.Sum();
            if (A.Length < 3 || sum % 3 != 0)
            {
                return 0;
            }

            int part = (int) Math.Floor((decimal) (sum / 3));
            int[,] table = new int[part + 1, A.Length + 1];

            for (int i = 1; i <= part; ++i)
            {
                for (int j = 1; j <= A.Length; ++j)
                {
                    int k = i - A[j - 1];
                    if (A[j - 1] == i || (k > 0 && table[k,j - 1] > 0))
                    {
                        if (table[i,j - 1] == 0)
                        {
                            table[i,j] = 1;
                        }
                        else
                        {
                            table[i,j] = 2;
                        }
                    }
                    else
                    {
                        table[i,j] = table[i,j - 1];
                    }
                }
            }

            if (table[part,A.Length] == 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}
