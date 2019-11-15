using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolboxAssignments.Week6
{
    class PlacingParentheses
    {
        //public static void Main(String[] args)
        //{
        //    var exp = Console.ReadLine();
        //    Console.WriteLine(GetMaximValue(exp));
        //}

        private static long GetMaximValue(String exp)
        {
            //write your code here
            return 0;
        }

        private static long Eval(long a, long b, char op)
        {
            if (op == '+')
            {
                return a + b;
            }
            else if (op == '-')
            {
                return a - b;
            }
            else if (op == '*')
            {
                return a * b;
            }
            else
            {
                return 0;
            }
        }
    }
}
