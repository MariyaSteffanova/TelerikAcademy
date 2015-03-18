//Problem 2. IEnumerable extensions

//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: 
//sum, product, min, max, average.
namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var intArr = new double[] { 5.0, 6.5, 7, 8, 0, 2.5, 1 };
            Test(intArr);

            var strArr = new string[] { "a", "bb", "ccc" };
            Test(strArr);

            var intList = new List<int>() { 1, 2, 3, 4 };
            Test(intList);

            var stringList = new List<string>() { "1", "21", "311", "4111" };
            Test(stringList);
        }

        public static void Test<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            Console.WriteLine(Environment.NewLine + "ELEMENTS OF List<int>: {0}", string.Join(" ", collection));
            Console.WriteLine("SUM: {0}", collection.Sum());
            Console.Write("PRODUCT: ");
            Console.WriteLine(collection.Product());
            Console.WriteLine("MAX VALUE: {0}", collection.Max());
            Console.WriteLine("MIN VALUE: {0}", collection.Min());
            Console.Write("AVERAGE: ");
            Console.WriteLine(collection.Average() + "\u0008");
        }
    }
}
