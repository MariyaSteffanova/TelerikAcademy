namespace Exam_Maslan
{
    using System;
    using System.Numerics;

   public class Maslan
    {
        public static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            BigInteger result = 1;
            BigInteger sum = 0;
            BigInteger transforms = 0;
            BigInteger currentNum = number;

            while (transforms < 10)
            {
                ExecuteTransform(ref result, ref sum, ref currentNum);

                transforms++;
                currentNum = result;

                if (!HasMoreThanOneDigit(currentNum)) 
                {
                    break;
                }
                
                sum = 0;
                result = 1;
            }

            PrintResult(transforms, currentNum);
        }

        private static bool HasMoreThanOneDigit(BigInteger number)
        {
            if (number >= 10)
            {
                return true;
            }

            return false;
        }

        private static void ExecuteTransform(ref BigInteger result, ref BigInteger sum, ref BigInteger currentNum)
        {
            while (HasMoreThanOneDigit(currentNum))
            {
                currentNum = currentNum / 10;
                sum = SumOddPositionDigits(currentNum);

                if (sum != 0)
                {
                    result *= sum;
                    sum = 0;
                }
            }
        }

        private static void PrintResult(BigInteger transforms, BigInteger currentNum)
        {
            if (transforms != 10)
            {
                Console.WriteLine(transforms);
            }

            Console.WriteLine(currentNum);
        }

        private static BigInteger SumOddPositionDigits(BigInteger currentNum)
        {
            string stringNum = currentNum.ToString();
            var sum = 0;

            for (int i = 0; i < stringNum.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sum += stringNum[i] - '0';
                }
            }

            return sum;
        }
    }
}
