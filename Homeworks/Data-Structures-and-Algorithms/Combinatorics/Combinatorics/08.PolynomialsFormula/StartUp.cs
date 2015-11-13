namespace PolynomialsFormula
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    class Program
    {
        static void Main()
        {
            var polyCoef = Console.ReadLine().ToArray();
            char a = polyCoef[1];
            char b = polyCoef[3];
            string input;
            do
            {
                input = Console.ReadLine().Trim();
            }
            while (string.IsNullOrEmpty(input));

            int pow = int.Parse(input);
            int n = pow + 1;

            long[] pascalCoef = new long[n];

            pascalCoef[0] = 1;

            for (long y = 0; y < n; y++)
            {
                long c = 1;

                for (long x = 0; x < y; x++)
                {
                    c = c * (y - x) / (x + 1);
                    pascalCoef[x + 1] = c;
                }

            }

          //   (c ^ 3) + 3(c ^ 2)(y ^ 1) + 3(c ^ 1)(y ^ 2) + (y ^ 3)
            var sb = new StringBuilder();
            sb.AppendFormat("({0}^{1})+", a, pow);
            var currentPowА = pow;
            var currentPowB = 0;
            for (int i = 1; i < n - 1; i++)
            {
                var coef = pascalCoef[i];
               
                    sb.AppendFormat("{0}({1}^{2})({3}^{4})+", coef, a, --currentPowА, b, ++currentPowB);
               
            }
            sb.AppendFormat("({0}^{1})", b, pow);

            Console.WriteLine(sb);
        }
    }
}
