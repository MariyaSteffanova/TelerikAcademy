namespace Exam_CalculationProblem
{
    using System;
    using System.Collections.Generic;

    public class CalculationProblem
    {
        public static void Main()
        {
            string[] alphabetDictionary = GetCatAlphabetDictionary();

            string[] inputWords = Console.ReadLine()
                                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var numbersInCatNumSystem =
                              GetNumberRepresentationOfInputWords(alphabetDictionary, inputWords);

            var numbersInDecimal = Convert.ToDecimal(numbersInCatNumSystem);
            int decimalSum = GetDecimalNumbersSum(numbersInDecimal);
            string catSystemSum = Convert.ToCatSystem(decimalSum);
            Console.WriteLine("{0} = {1}", catSystemSum, decimalSum);
        }

        private static int GetDecimalNumbersSum(List<int> numbersInDecimal)
        {
            int decimalSum = 0;

            for (int i = 0; i < numbersInDecimal.Count; i++)
            {
                decimalSum += numbersInDecimal[i];
            }

            return decimalSum;
        }

        private static List<List<int>> GetNumberRepresentationOfInputWords(string[] alphabetDictionary, string[] inputWords)
        {
            List<List<int>> wordsAsNumbersInCatNumSystem = new List<List<int>>();

            for (int j = 0; j < inputWords.Length; j++)
            {
                string currentWord = inputWords[j];

                var wordAsNumber = GetNumberRepresentationOfWord(alphabetDictionary, currentWord);

                wordsAsNumbersInCatNumSystem.Add(wordAsNumber);
            }

            return wordsAsNumbersInCatNumSystem;
        }

        private static List<int> GetNumberRepresentationOfWord(string[] alphabetDictionary, string currentWord)
        {
            var wordAsNumber = new List<int>();
            foreach (var letter in currentWord)
            {
                for (int index = 0; index < alphabetDictionary.Length; index++)
                {
                    if (letter.ToString() == alphabetDictionary[index])
                    {
                        wordAsNumber.Add(index);
                    }
                }
            }

            return wordAsNumber;
        }

        private static string[] GetCatAlphabetDictionary()
        {
            string[] catNumbersDict = new string[23];
            for (int i = 0; i < catNumbersDict.Length; i++)
            {
                catNumbersDict[i] = ((char)(97 + i)).ToString();
            }

            return catNumbersDict;
        }
    }
}