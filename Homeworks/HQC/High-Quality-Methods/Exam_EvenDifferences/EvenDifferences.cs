namespace Exam_EvenDifferences
{
    using System;
    using System.Linq;
    using System.Numerics;

   public class EvenDifferences
    {
       public static void Main()
        {
            BigInteger[] sequence = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(BigInteger.Parse)
                 .ToArray();

            int startIndex = 1;
            BigInteger abs = 0;
            BigInteger sumEvenAbs = 0;

            while (startIndex < sequence.Length)
            {
                abs = BigInteger.Max(sequence[startIndex], sequence[startIndex - 1]) - BigInteger.Min(sequence[startIndex], sequence[startIndex - 1]);
               
                if (abs % 2 == 0) 
                {
                    sumEvenAbs += abs;
                    startIndex += 2;
                }
                else
                {
                    startIndex += 1;
                }
            }

            Console.WriteLine(sumEvenAbs);
        }
    }
}
