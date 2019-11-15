namespace AlgorithmicToolboxAssignments.Week2
{
    class LCM
    {
        //static void Main(string[] args)
        //{
        //    var n = Console.ReadLine();
        //    var a = int.Parse(n.Split(' ')[0]);
        //    var b = int.Parse(n.Split(' ')[1]);
        //    var c = GetLcm(a, b);
        //    Console.WriteLine(c);
        //}

        private static long GetLcm(int a, int b)
        {
            return (long)a * b / GetGcd(a, b);
        }

        private static int GetGcd(int a, int b)
        {
            if (b == 0)
                return a;

            int aDash = a % b;
            return GetGcd(b, aDash);
        }
    }
}
