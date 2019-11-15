using System;

namespace AlgorithmicToolboxAssignments.Week3
{
    class Change
    {
        //static void Main(string[] args)
        //{
        //    var m = int.Parse(Console.ReadLine());
        //    int c = GetChange(m);
        //    Console.WriteLine(c);
        //}

        private static int GetChange(int m)
        {
            int coinsCount = 0;

            while (m > 0)
            {
                if (m >= 10)
                {
                    coinsCount++;
                    m -= 10;
                }
                else if (m >= 5)
                {
                    coinsCount++;
                    m -= 5;
                }
                else
                {
                    coinsCount++;
                    m -= 1;
                }
            }

            return coinsCount;
        }
    }
}
