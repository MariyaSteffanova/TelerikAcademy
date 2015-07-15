namespace AlgorithmsTesting
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class Tester
    {
        private const int CollectionSize = 20;

        public static void TestSort(Algorithm algorithm)
        {
            Console.WriteLine("TESTS {0} SORT", algorithm.ToString().ToUpper());
            Console.WriteLine(new string('=', 40));
            TestSort<int>(algorithm, CollectionOrder.Random);
            TestSort<int>(algorithm, CollectionOrder.Reversed);
            TestSort<int>(algorithm, CollectionOrder.Sorted);

            TestSort<double>(algorithm, CollectionOrder.Random);
            TestSort<double>(algorithm, CollectionOrder.Reversed);
            TestSort<double>(algorithm, CollectionOrder.Sorted);

            TestSort<string>(algorithm, CollectionOrder.Random);
            TestSort<string>(algorithm, CollectionOrder.Reversed);
            TestSort<string>(algorithm, CollectionOrder.Sorted);
        }

        public static void TestSort<T>(Algorithm algorithm, CollectionOrder order)
            where T : IComparable
        {
            var result = new StringBuilder();
            var type = typeof(T);
            result.AppendFormat("{0,10} | ", type.ToString().Replace("System.", string.Empty));

            var stopwatch = new Stopwatch();

            var collection = CollectionGenerator.GetCollection<T>(CollectionSize, order);

            stopwatch.Start();
            switch (algorithm)
            {
                case Algorithm.Selection:
                    SortingAlgorithms.SelectionSort<T>(collection);
                    break;
                case Algorithm.Insertion:
                    SortingAlgorithms.InsertionSort<T>(collection);
                    break;
                case Algorithm.Qiuck:
                    SortingAlgorithms.QuickSort<T>(collection, 0, collection.Length - 1);
                    break;
                default:
                    break;
            }

            stopwatch.Stop();
            result.AppendFormat("{0,-20}:{1}", order + " values", stopwatch.Elapsed).AppendLine();
            stopwatch.Reset();

            Console.WriteLine(result);
        }
    }
}
