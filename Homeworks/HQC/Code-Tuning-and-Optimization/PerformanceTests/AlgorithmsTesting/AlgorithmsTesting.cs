namespace AlgorithmsTesting
{
    using System;

    public class AlgorithmsTesting
    {
        public static void Main()
        {
            var random = Common.GetRandomizedArray();
            var sorted = Common.GetSortedArray();
            var reversed = Common.GetReversedArray();
            SortingAlgorithms.SelectionSort(random);
            Console.WriteLine(string.Join(", ", reversed));
        }
    }
}
