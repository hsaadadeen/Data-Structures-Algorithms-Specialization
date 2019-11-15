using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsonStrings.Week2
{
    class bwt
    {
        //static void Main(string[] args)
        //{
        //    string text = Console.ReadLine();

        //    string answer = BWT(text);
        //    Console.WriteLine(answer);
        //}

        private static string BWT(string text)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder textBuilder = new StringBuilder(text);

            SortedSet<string> tree = new SortedSet<string>();

            for (int i = 0; i < text.Length; i++)
            {
                tree.Add(textBuilder.ToString());
                textBuilder.Append(textBuilder[0]);
                textBuilder.Remove(0, 1);
            }

            int last = text.Length - 1;
            foreach (var line in tree)
            {
                result.Append(line[last]);
            }

            return result.ToString();
        }
    }
}
