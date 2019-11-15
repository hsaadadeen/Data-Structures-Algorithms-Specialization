using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolboxAssignments.Week5
{
    class PrimitiveCalculator
    {
        //public static void Main(String[] args)
        //{
        //    var m = int.Parse(Console.ReadLine());
        //    var sequence = Optimal_sequence(m);
        //    Console.WriteLine(sequence.Count - 1);
        //    foreach (int x in sequence)
        //    {
        //        Console.Write(x + " ");
        //    }
        //}

        private static LinkedList<int> Optimal_sequence(int number)
        {
            int[] min_steps = new int[number + 1];
            int[] predecessor = new int[number + 1];

            for (int i = 2; i <= number; i++)
            {
                min_steps[i] = min_steps[i - 1] + 1;
                predecessor[i] = i - 1;
                if (i % 3 == 0)
                {
                    if (min_steps[i / 3] < min_steps[i])
                    {
                        min_steps[i] = min_steps[i / 3] + 1;
                        predecessor[i] = i / 3;
                    }
                }
                if (i % 2 == 0)
                {
                    if (min_steps[i / 2] < min_steps[i])
                    {
                        min_steps[i] = min_steps[i / 2] + 1;
                        predecessor[i] = i / 2;
                    }
                }
            }

            LinkedList<int> sequence = new LinkedList<int>();
            for (int i = number; i != 0; i = predecessor[i])
            {
                sequence.AddFirst(i);
            }
            
            return sequence;
        }

}
}
