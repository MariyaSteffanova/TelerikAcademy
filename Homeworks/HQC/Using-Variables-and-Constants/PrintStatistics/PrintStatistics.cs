namespace PrintStatistics
{
    using System;

    public class PrintStatistics
    {
        public static void Main()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            var max = numbers.GetMaxToString();

            ArrayExtensionMethods.PrintStatistics(numbers);

            Console.WriteLine(new string('=', 40));
            Console.WriteLine("{0}{1}", max, Environment.NewLine);
        }
    }
}
