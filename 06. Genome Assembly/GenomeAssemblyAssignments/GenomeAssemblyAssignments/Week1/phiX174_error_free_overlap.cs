using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomeAssemblyAssignments.Week1
{
    class phiX174_error_free_overlap
    {
        static void Main(string[] args)
        {
            List<string> reads = new List<string>(1618);

            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                reads.Add(line);
            }

            Console.WriteLine(AssembleGenome(reads, 12));
        }

        private static string AssembleGenome(List<string> reads, int mer)
        {
            StringBuilder genome = new StringBuilder(1000);
            genome.Append(reads[0]);

            string firstRead = reads[0], curRead = "";
            int curIndex = 0;

            while (reads.Count > 1)
            {
                curRead = reads[curIndex];
                reads.RemoveAt(curIndex);

                int maxOverlap = -1;

                for (int i = 0; i < reads.Count; i++)
                {
                    int overlap = CalculateOverlap(curRead, reads[i], mer);
                    if (overlap > maxOverlap)
                    {
                        maxOverlap = overlap;
                        curIndex = i;
                    }
                }

                genome.Append(reads[curIndex].Substring(maxOverlap));
            }

            genome.Remove(0, CalculateOverlap(reads[0], firstRead, mer));
            return genome.ToString();
        }

        private static int CalculateOverlap(string a, string b, int mer)
        {
            for (int i = 0, n = 1 + a.Length-mer; i < n; i++)
            {
                if (string.Compare(b, 0, a, i, a.Length - i) == 0)
                    return a.Length - i;
            }

            return 0;
        }
    }
}
