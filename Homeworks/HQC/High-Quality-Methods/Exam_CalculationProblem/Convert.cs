namespace Exam_CalculationProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Convert
    {
        public static List<int> ToDecimal(List<List<int>> wordsAsNumbersInCatNumSystem)
        {
            var numbersInDecimal = new List<int>();
            int numberInDecimal = 0;

            for (int currentNum = 0; currentNum < wordsAsNumbersInCatNumSystem.Count; currentNum++)
            {
                for (int currentDigit = 0; currentDigit < wordsAsNumbersInCatNumSystem[currentNum].Count; currentDigit++)
                {
                    int pow = wordsAsNumbersInCatNumSystem[currentNum].Count - currentDigit - 1;
                    int curentDigit = wordsAsNumbersInCatNumSystem[currentNum][currentDigit];
                    numberInDecimal += curentDigit * (int)Math.Pow(23, pow);
                }

                numbersInDecimal.Add(numberInDecimal);
                numberInDecimal = 0;
            }

            return numbersInDecimal;
        }

        public static string ToCatSystem(int decimalResult)
        {
            var numBase = 23;
            string result = string.Empty;

            if (decimalResult == 0)
            {
                result = "0";
            }

            while (decimalResult > 0)
            {
                int remainder = decimalResult % numBase;
                result += (char)(remainder + 97);
                decimalResult /= numBase;
            }

            var reverseResult = result.ToCharArray().Reverse();
            return string.Join(string.Empty, reverseResult);
        }
    }
}
