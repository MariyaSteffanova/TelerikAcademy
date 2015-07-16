namespace Exam_SequencesOfBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequencesOfBits
    {
        public static void Main()
        {
            int[] numbers = IO.ReadInput();
            string[] binaryNumbers = ConvertToBinary(numbers);

            var ones = GetSequence(binaryNumbers, '0');
            var zeroes = GetSequence(binaryNumbers, '1');

            var maxSequenceOnes = ones.Max().Length;
            var maxSequenceZeroes = zeroes.Max().Length;

            Console.WriteLine(maxSequenceOnes);
            Console.WriteLine(maxSequenceZeroes);
        }

        private static string[] GetSequence(string[] binaryNumbers, char p)
        {
            string binarySequence = string.Join(string.Empty, binaryNumbers);
            string[] targetSequence = binarySequence.Split(p);

            return targetSequence;
        }

        private static string[] ConvertToBinary(int[] numbers)
        {
            var binary = new string[numbers.Length];

            for (int index = 0; index < numbers.Length; index++)
            {
                binary[index] = Convert.ToString(numbers[index], 2).PadLeft(30, '0');
            }

            return binary;
        }
    }
}
