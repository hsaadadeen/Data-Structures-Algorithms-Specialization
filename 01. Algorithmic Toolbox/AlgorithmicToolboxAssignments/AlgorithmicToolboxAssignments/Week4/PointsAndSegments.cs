using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolboxAssignments.Week4
{
    class PointsAndSegments
    {
        //public static void Main(String[] args)
        //{
        //    var line = Console.ReadLine();
        //    int n = int.Parse(line.Split(' ')[0]);
        //    int m = int.Parse(line.Split(' ')[1]);
        //    int[] starts = new int[n];
        //    int[] ends = new int[n];
        //    int[] points = new int[m];
        //    for (int i = 0; i < n; i++)
        //    {
        //        line = Console.ReadLine();
        //        starts[i] = int.Parse(line.Split(' ')[0]);
        //        ends[i] = int.Parse(line.Split(' ')[1]);
        //    }
        //    line = Console.ReadLine();
        //    for (int i = 0; i < m; i++)
        //    {
        //        points[i] = int.Parse(line.Split(' ')[i]);
        //    }
        //    //use fastCountSegments
        //    int[] cnt = NaiveCountSegments(starts, ends, points);
        //    foreach (var x in cnt)
        //    {
        //        Console.Write(x + " ");
        //    }
        //}

        private static int[] FastCountSegments(int[] starts, int[] ends, int[] points)
        {
            int[] cnt = new int[points.Length];
            

            return cnt;
        }

        private static int[] NaiveCountSegments(int[] starts, int[] ends, int[] points)
        {
            int[] cnt = new int[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < starts.Length; j++)
                {
                    if (starts[j] <= points[i] && points[i] <= ends[j])
                    {
                        cnt[i]++;
                    }
                }
            }
            return cnt;
        }
    }
}
