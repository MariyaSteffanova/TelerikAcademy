namespace PrintStatistics
{
    using System;
    using System.Linq;
    using System.Text;

    public static class ArrayExtensionMethods
    {
        public static void PrintStatistics<T>(T[] numbers)
        {
            var statistics = new StringBuilder();
            statistics.AppendLine(numbers.GetMinToString());
            statistics.AppendLine(numbers.GetMaxToString());
            statistics.AppendLine(numbers.GetAverageToString());

            Console.WriteLine(statistics);
        }

        public static string GetMinToString<T>(this T[] numbers)
        {
            return string.Format("Min: {0}", numbers.Min());
        }

        public static string GetMaxToString<T>(this T[] numbers)
        {
            return string.Format("Max: {0}", numbers.Max());
        }

        public static string GetAverageToString<T>(this T[] numbers)
        {
            return string.Format("Average: {0}", numbers.GetAverage());
        }

        public static T GetAverage<T>(this T[] numbers)
        {
            dynamic sum = 0;
            var length = numbers.Length;

            for (int index = 0; index < length; index++)
            {
                sum += numbers[index];
            }

            return sum / length;
        }
    }
}
