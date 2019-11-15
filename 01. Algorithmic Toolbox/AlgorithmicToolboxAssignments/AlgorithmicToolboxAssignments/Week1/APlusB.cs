using System;

namespace APlusB
{
    class Week1
    {
        static void APlusB(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            var a = int.Parse(tokens[0]);
            var b = int.Parse(tokens[1]);
            Console.WriteLine(a + b);
        }
    }
}