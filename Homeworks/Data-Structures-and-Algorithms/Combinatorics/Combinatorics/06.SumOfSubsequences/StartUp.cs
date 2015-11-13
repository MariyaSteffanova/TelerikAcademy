namespace _06.SumOfSubsequences
{
    using System;
    using System.Linq;
    using System.Numerics;

    class StartUp
    {
        static void Main()
        {
            var test = int.Parse(Console.ReadLine());

            var factorials = new BigInteger[1001];

            factorials[0] = 1;

            for (int i = 0; i < 1000; i++)
            {
                factorials[i + 1] = factorials[i] * (i + 1);
            }

            for (int i = 0; i < test; i++)
            {
                var nk = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var n = nk[0];
                var k = nk[1];

                int sum = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Sum();

                var coef = factorials[n - 1] / (factorials[n - k - 1] * factorials[k]);

                
                Console.WriteLine(coef * sum);

            }
        }
    }
}
