using System;

namespace AlgorithmicToolboxAssignments.Week4
{
    class Inversions
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

        //    int[] b = new int[n];
        //    Console.WriteLine(GetNumberOfInversions(a, b, 0, a.Length - 1));
        //}

        private static long GetNumberOfInversions(int[] a, int[] b, int left, int right)
        {
            long numberOfInversions = 0;
            if (right <= left + 1)
            {
                return numberOfInversions;
            }
            int ave = (left + right) / 2;
            numberOfInversions += GetNumberOfInversions(a, b, left, ave);
            numberOfInversions += GetNumberOfInversions(a, b, ave, right);
            numberOfInversions += Merge(a, b, left, ave + 1, right);

            return numberOfInversions;
        }

        private static long Merge(int[] a, int[] b, int left, int ave, int right)
        {
            int i = left, j = ave, k = left;
            long inv_count = 0;
            while (i <= ave - 1 && j <= right)
            {
                if (a[i] <= a[j])
                {
                    b[k] = a[i];
                    i++;
                }
                else
                {
                    b[k] = a[j];
                    inv_count += ave - i;
                    j++;
                }
                k++;
            }
            while (i <= ave - 1)
            {
                b[k] = a[i];
                i++;
                k++;
            }
            while (j <= right)
            {
                b[k] = a[j];
                j++;
                k++;
            }
            for (i = left; i <= right; i++)
            {
                a[i] = b[i];
            }
            return inv_count;
        }
    }
}
