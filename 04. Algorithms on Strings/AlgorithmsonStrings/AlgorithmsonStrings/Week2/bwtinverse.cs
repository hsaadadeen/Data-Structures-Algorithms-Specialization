using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsonStrings.Week2
{
    class bwtinverse
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string answer = InverseBWT(text);
            Console.WriteLine(answer);
        }

        private static string InverseBWT(string bwt)
        {
            StringBuilder result = new StringBuilder();
            List<string> matrix = new List<string>();
            List<int> indexes = new List<int>();
            for (int i = 0; i < bwt.Length; i++)
            {
                matrix.Add("" + bwt[i]);
                indexes.Add(i);
            }

            indexes.Sort((o1, o2) => matrix[o1].CompareTo(matrix[o2]));
            int current = indexes[0];
            for (int i = 0; i < bwt.Length - 1; i++)
            {
                int index = indexes.IndexOf(current);
                string next = bwt[index].ToString();
                result.Append(next);
                current = index;
            }

            return new string(result.ToString().Reverse().ToArray()) + "$";
        }
    }
}
