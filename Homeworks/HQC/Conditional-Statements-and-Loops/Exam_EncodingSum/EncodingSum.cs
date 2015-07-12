namespace Exam_EncodingSum
{
    using System;

    public class EncodingSum
    {
        public const char EndChar = '@';

        public static void Main()
        {
            int module = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            long result = GetEncodedValue(text, module);
            Console.WriteLine(result);
        }

        private static long GetEncodedValue(string text, int module)
        {
            long result = 0;
            foreach (var symbol in text)
            {
                if (symbol == EndChar)
                {
                    return result;
                }
                else if (Char.IsDigit(symbol))
                {
                    result *= symbol - '0';
                }
                else if (Char.IsLetter(symbol))
                {
                    result += Char.ToUpper(symbol) - 'A';
                }
                else
                {
                    result = result % module;
                }
            }

            return result;
        }
    }
}
