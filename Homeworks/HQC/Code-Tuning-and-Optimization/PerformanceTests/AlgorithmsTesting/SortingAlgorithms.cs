namespace AlgorithmsTesting
{
    using System;
    using System.Collections;

    public class SortingAlgorithms
    {

        public static void InsertionSort<T>(T[] numbers)  
            where T: IComparable
        {
            int index;
            for (int i = 0; i < numbers.Length; i++)
            {
                index = i;
                while (index > 0 && numbers[index-1].CompareTo(numbers[index])>0)
                {
                    var temp = numbers[index - 1];
                    numbers[index - 1] = numbers[index];
                    numbers[index] = temp;
                    
                    index--;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
        public static void SelectionSort<T>(T[] numbers)
            where T: IComparable
        {
            int minIndex;

            for (int i = 0; i < numbers.Length; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j].CompareTo(numbers[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    var holder = numbers[minIndex];
                    numbers[minIndex] = numbers[i];
                    numbers[i] = holder;
                }
            }
        }
    }
}
