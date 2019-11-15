using System;
using System.Collections.Generic;

namespace AlgorithmicToolboxAssignments.Week5
{
    class ChangeDP
    {
        private static List<int> coins = new List<int>() { 1, 3, 4 };

        //public static void Main(String[] args)
        //{
        //    var m = int.Parse(Console.ReadLine());
        //    Console.WriteLine(GetChange(m));

        //}

        private static int GetChange(int m)
        {
            int[] table = new int[m + 1];

            table[0] = 0;

            for (int i = 1; i <= m; ++i)
            {
                table[i] = int.MaxValue;
            }

            for (int i = 1; i <= m; ++i)
            {
                for (int j = 0; j < coins.Count; ++j)
                {
                    if (coins[j] <= i)
                    {
                        int sub_res = table[i - coins[j]];
                        if (sub_res != int.MaxValue && sub_res + 1 < table[i])
                        {
                            table[i] = sub_res + 1;
                        }
                    }
                }
            }
            return table[m];

        }

    }
}
