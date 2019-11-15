using System;
using System.Collections.Generic;

namespace AlgorithmicToolboxAssignments.Week3
{
    class CoveringSegments
    {
        private class Segment
        {
            internal int Start, End;

            internal Segment(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }
        }

        //static void Main(string[] args)
        //{
        //    var n = int.Parse(Console.ReadLine());
        //    Segment[] segments = new Segment[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        var l = Console.ReadLine();
        //        segments[i] = new Segment(int.Parse(l.Split(' ')[0]), int.Parse(l.Split(' ')[1]));
        //    }
        //    int[] points = OptimalPoints(segments);

        //    Console.WriteLine(points.Length);
        //    foreach (var point in points)
        //        Console.Write(point + " ");
        //}

        private static int[] OptimalPoints(Segment[] segments)
        {
            int[] points = new int[2 * segments.Length];

            Array.Sort(segments, Comparer<Segment>.Create((x, y) => x.End.CompareTo(y.End)));

            int point = segments[0].End;
            points[0] = point;

            int j = 1;
            for (int i = 1; i < segments.Length; i++)
            {
                if (point < segments[i].Start || point > segments[i].End)
                {
                    point = segments[i].End;
                    points[j] = point;
                    j++;
                }
            }
            int[] pointsFinal = new int[j];
            for (int i = 0; i < j; i++)
            {
                pointsFinal[i] = points[i];
            }
            return pointsFinal;
        }
    }
}
