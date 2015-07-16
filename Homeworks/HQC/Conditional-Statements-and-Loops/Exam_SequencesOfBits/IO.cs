namespace Exam_SequencesOfBits
{
    using System;

    public class IO
    {
        public static int[] ReadInput()
        {
            int numLinesInput = int.Parse(Console.ReadLine());
            int[] numbers = new int[numLinesInput];

            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = int.Parse(Console.ReadLine());
            }

            return numbers;
        }
    }
}
