using System;

namespace AlgorithmicToolboxAssignments.Week4
{
    class BinarySearch
    {
        //public static void Main(string[] args)
        //{
        //    var line = Console.ReadLine();
        //    var tokens = line.Split(' ');
        //    int n = int.Parse(tokens[0]);
        //    int[] a = new int[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        a[i] = int.Parse(tokens[i + 1]);
        //    }

        //    line = Console.ReadLine();
        //    tokens = line.Split(' ');
        //    int m = int.Parse(tokens[0]);
        //    int[] b = new int[m];
        //    for (int i = 0; i < m; i++)
        //    {
        //        b[i] = int.Parse(tokens[i + 1]);
        //    }

        //    for (int i = 0; i < m; i++)
        //    {
        //        Console.Write(BinarySearchRecursive(a, b[i], 0, a.Length-1) + " ");
        //    }
        //}

        static int BinarySearchRecursive(int[] a, int x, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }
            else
            {
                int mid = (left + right) / 2;
                if (x == a[mid])
                {
                    return mid;
                }
                else if (x < a[mid])
                {
                    return BinarySearchRecursive(a, x, left, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(a, x, mid + 1, right);
                }
            }
        }

        static int DoLinearSearch(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x) return i;
            }
            return -1;
        }

        
    }
}
