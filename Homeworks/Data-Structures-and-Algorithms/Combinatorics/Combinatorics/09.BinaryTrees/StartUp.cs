namespace _09.BinaryTrees
{
    using System;
    using System.Numerics;

    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var depth = input.Length;
            var groups = new int[26];

            foreach (var ball in input)
            {
                groups[ball - 'A']++;
            }

            var factorials = new BigInteger[2 * depth + 1];
            factorials[0] = 1;

            for (int i = 0; i < depth * 2; i++)
            {
                factorials[i + 1] = factorials[i] * (i + 1);
            }

            var nColors = factorials[depth];
            foreach (var x in groups)
            {
                nColors /= factorials[x];
            }

            var perTree = factorials[2 * depth] / (factorials[depth + 1] * factorials[depth]);


            Console.WriteLine(perTree * nColors);

        }


    }
}
