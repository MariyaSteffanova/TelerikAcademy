namespace AlgorithmsTesting
{
    using System;
    using System.Collections;

    public class SortingAlgorithms
    {
        public static void InsertionSort<T>(T[] collection)
            where T : IComparable
        {
            int index;
            for (int i = 0; i < collection.Length; i++)
            {
                index = i;
                while (index > 0 && collection[index - 1].CompareTo(collection[index]) > 0)
                {
                    var temp = collection[index - 1];
                    collection[index - 1] = collection[index];
                    collection[index] = temp;

                    index--;
                }
            }
        }

        public static void SelectionSort<T>(T[] collection)
            where T : IComparable
        {
            int minIndex;

            for (int i = 0; i < collection.Length; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < collection.Length; j++)
                {
                    if (collection[j].CompareTo(collection[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    var holder = collection[minIndex];
                    collection[minIndex] = collection[i];
                    collection[i] = holder;
                }
            }
        }

        // TODO: QuickSort with recursion and Generic :)
        public static void QuickSort<T>(T[] collection, int left, int right)
            where T : IComparable
        {
            if (left >= right)
            {
                return;
            }

            int pivotIndex = (left + right) / 2;
            T pivot = collection[pivotIndex];

            int leftPointer = left;
            int rightPointer = right;

            while (leftPointer <= rightPointer)
            {
                while (collection[leftPointer].CompareTo(pivot) < 0)
                {
                    leftPointer++;
                }

                while (collection[rightPointer].CompareTo(pivot) > 0)
                {
                    rightPointer--;
                }

                if (leftPointer <= rightPointer)
                {
                    T holder = collection[rightPointer];
                    collection[rightPointer] = collection[leftPointer];
                    collection[leftPointer] = holder;

                    leftPointer++;
                    rightPointer--;
                }
            }

            if (left < rightPointer)
            {
                QuickSort(collection, left, rightPointer);
            }

            if (leftPointer < right)
            {
                QuickSort(collection, leftPointer, right);
            }
        }
    }
}
