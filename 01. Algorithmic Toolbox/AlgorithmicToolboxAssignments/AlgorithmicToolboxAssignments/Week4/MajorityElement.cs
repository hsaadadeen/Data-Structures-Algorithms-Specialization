using System;

namespace AlgorithmicToolboxAssignments.Week4
{
    class MajorityElement
    {
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

        //    if (GetMajorityElement(a, 0, a.Length) != -1)
        //    {
        //        Console.WriteLine(1);
        //    }
        //    else
        //    {
        //        Console.WriteLine(0);
        //    }
        //}

        private static int GetMajorityElement(int[] a, int left, int right)
        {
            if (left == right)
            {
                return -1;
            }
            if (left + 1 == right)
            {
                return a[left];
            }

            int left_elem = GetMajorityElement(a, left, (left + right - 1) / 2 + 1);
            int right_elem = GetMajorityElement(a, (left + right - 1) / 2 + 1, right);

            int lcount = 0;
            for (int i = left; i < right; i++)
            {
                if (a[i] == left_elem)
                    lcount += 1;
            }
            if (lcount > (right - left) / 2)
                return left_elem;

            int rcount = 0;
            for (int i = left; i < right; i++)
            {
                if (a[i] == right_elem)
                    rcount += 1;
            }
            if (rcount > (right - left) / 2)
                return right_elem;

            return -1;
        }
    }
}
