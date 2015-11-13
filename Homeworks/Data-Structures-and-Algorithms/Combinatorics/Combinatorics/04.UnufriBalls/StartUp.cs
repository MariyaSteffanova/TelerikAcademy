namespace _04.UnufriBalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    class StartUp
    {
        static void Main()
        {
            //RYYRYBY -> N = 7, K =3,
            //[R] -> 2
            //[Y] -> 4
            //[B] -> 1
            
            var input = Console.ReadLine().Trim();
            var balls = new Dictionary<char,int>();
            int N = input.Length;
            int K;

            for (int i = 0; i < input.Length; i++)
            {
                var ch = input[i];
                if (!balls.ContainsKey(ch))
                {
                    balls.Add(ch, 0);
                }

                balls[ch]++;
            }

            var factorials = new BigInteger[N+2];

            factorials[0] = 1;

            for (int i = 0; i <= N; i++)
            {
                factorials[i + 1] = factorials[i] * (i + 1);
            }

           

           
            var permutations = factorials[N];

           
            foreach (var x in balls.Values)
            {
                permutations /= factorials[x];
            }

           // result *= nColors;
            Console.WriteLine(permutations);

        }
    }
}
