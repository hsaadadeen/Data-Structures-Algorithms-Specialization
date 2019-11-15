using System;
using System.Collections.Generic;

namespace AlgorithmicToolboxAssignments.Week4
{
    class Sorting
    {
        private static Random random = new Random();

        //public static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    var line = Console.ReadLine();
        //    var tokens = line.Split(' ');
        //    int[] a = new int[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        a[i] = int.Parse(tokens[i]);
        //    }

        //    RandomizedQuickSort(a, 0, n - 1);
        //    for (int i = 0; i < n; i++)
        //    {
        //        Console.Write(a[i] + " ");
        //    }
        //}

        private static int[] Partition3(int[] a, int l, int r)
        {
            int x = a[l];
            int i = l;
            int m1 = l;
            int m2 = r;
            int[] m = { m1, m2 };

            while (i <= m2)
            {
                if (a[i] < x)
                {
                    Swap(a, i, m1);
                    m1++;
                    i++;
                }
                else if (a[i] == x)
                {
                    i++;
                }
                else
                {
                    Swap(a, i, m2);
                    m2 -= 1;
                }
                m[0] = m1;
                m[1] = m2;
            }
            return m;
        }

        private static int Partition2(int[] a, int l, int r)
        {
            int x = a[l];
            int j = l;
            for (int i = l + 1; i <= r; i++)
            {
                if (a[i] <= x)
                {
                    j++;
                    Swap(a, i, j);
                }
            }
            Swap(a, l, j);
            return j;
        }

        private static void Swap(int[] a, int i, int m2)
        {
            int tp = a[i];
            a[i] = a[m2];
            a[m2] = tp;
        }

        private static void RandomizedQuickSort(int[] a, int l, int r)
        {
            if (l >= r)
            {
                return;
            }
            int k = random.Next(r - l + 1) + l;
            Swap(a, l, k);
            
            int[] m = Partition3(a, l, r);
            RandomizedQuickSort(a, l, m[0] - 1);
            RandomizedQuickSort(a, m[1] + 1, r);
        }

    }
}
