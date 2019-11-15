using System;
using System.Threading;

namespace AlgorithmicToolboxAssignments.Week1
{
    class Week1
    {
        static void Main2(string[] args)
        {
            //StressTest(10, 100000);

            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            int[] numbers = new int[tokens.Length];

            for (int i = 0; i < n; i++)
                numbers[i] = int.Parse(tokens[i]);

            long product = MaxPairwiseProductFast(numbers);

            Console.WriteLine(product);
        }

        private static long MaxPairwiseProductFast(int[] numbers)
        {
            if (numbers.Length < 2) return 0;

            int max = 0, secondMax = 1;

            if (numbers[1] > numbers[0])
            {
                max = 1;
                secondMax = 0;
            }

            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[max])
                {
                    secondMax = max;
                    max = i;
                }
                else if (numbers[i] > numbers[secondMax])
                {
                    secondMax = i;
                }
            }

            return (long)numbers[max] * numbers[secondMax];
        }

        private static long MaxPairwiseProduct(int[] numbers)
        {
            long product = 0;
            int n = numbers.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    product = Math.Max(product, (long)numbers[i] * numbers[j]);
                }
            }
            return product;
        }

        private static void StressTest(int n, int m)
        {
            Random rnd = new Random();
            int ni = n;
            while (true)
            {
                n = rnd.Next(2, ni);
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                    arr[i] = rnd.Next(0, m);
                Console.WriteLine(string.Join(" ", arr));
                var result1 = MaxPairwiseProduct(arr);
                var result2 = MaxPairwiseProductFast(arr);
                if(result1 == result2)
                    Console.WriteLine("OK");
                else
                    Console.WriteLine("Wrong answer: {0}, {1}", result1, result2);
                Thread.Sleep(500);
            }

        }

    }
}
