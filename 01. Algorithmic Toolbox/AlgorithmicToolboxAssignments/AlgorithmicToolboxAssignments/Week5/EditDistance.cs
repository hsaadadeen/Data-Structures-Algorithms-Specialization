using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolboxAssignments.Week5
{
    class EditDistance
    {
        //public static void Main(String[] args)
        //{
        //    var s = Console.ReadLine();
        //    var t = Console.ReadLine();
        //    Console.WriteLine(Edit_distance(s, t));

        //}

        private static int Edit_distance(string s, string t)
        {
            int[,] dp = new int[s.Length + 1, t.Length + 1];

            for (int i = 0; i <= s.Length; ++i)
            {
                for (int j = 0; j <= t.Length; ++j)
                {
                    if (i == 0)
                    {
                        dp[i,j] = j;
                    }

                    else if (j == 0)
                    {
                        dp[i,j] = i;
                    }

                    else if (s[i - 1] == t[j - 1])
                    {
                        dp[i,j] = dp[i - 1,j - 1];
                    }

                    else
                    {
                        dp[i,j] = 1 + Math.Min(Math.Min(dp[i,j - 1], dp[i - 1,j]), dp[i - 1,j - 1]);
                    }
                }
            }
            return dp[s.Length,t.Length];
        }
    }
}
