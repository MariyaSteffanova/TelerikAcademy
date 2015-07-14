namespace AlgorithmsTesting
{
    using System;
    using System.Collections;

    public enum CollectionOrder
    {
        Random, Sorted, Reversed
    }

    public enum TypeArray
    {
        Int, Double, String
    }

    public static class CollectionGenerator
    {
        private const double ConstFraction = 0.5;
        private const int FirstLetterCodeASCII = 65;
        private const int LastLetterCodeASCII = 91;
        private const int MinValue = -300;
        private const int MaxValue = 300;

        public static T[] GetCollection<T>(int size, CollectionOrder order)
            where T : IComparable
        {
            var collection = new T[size];
            switch (order)
            {
                case CollectionOrder.Random:
                    collection = GetRandomizedArray<T>(size);
                    break;
                case CollectionOrder.Sorted:
                    collection = GetSortedArray<T>(size);
                    break;
                case CollectionOrder.Reversed:
                    collection = GetReversedArray<T>(size);
                    break;
                default:
                    break;
            }

            return collection;
        }

        public static T[] GetReversedArray<T>(int size)
            where T : IComparable
        {
            T[] array = new T[size];
            switch (array.GetType().Name)
            {
                case "Int[]":

                    for (int index = 0; index < size; index++)
                    {
                        array[index] = (dynamic)size - index - 1;
                    }

                    break;
                case "Double[]":                    
                        for (int index = 0; index < size; index++)
                        {
                            array[index] = (dynamic)size - index - ConstFraction;
                        }
                    
                    break;
                case "String[]":
                    for (int index = 0; index < size; index++)
                    {
                        array[index] = (dynamic)((char)(size - index - 1 + FirstLetterCodeASCII)).ToString();
                    }

                    break;
                default:
                    break;
            }

            return array;
        }

        public static T[] GetSortedArray<T>(int size)
            where T : IComparable
        {
            T[] array = new T[size];
            switch (array.GetType().Name)
            {
                case "Int[]":
                    for (int index = 0; index < array.Length; index++)
                    {
                        array[index] = (dynamic)index;
                    }

                    break;
                case "Double[]":
                    for (int index = 0; index < array.Length; index++)
                    {
                        array[index] = (dynamic)index + ConstFraction;
                    }

                    break;

                case "String[]":
                    for (int index = 0; index < array.Length; index++)
                    {
                        array[index] = (dynamic)((char)(index + FirstLetterCodeASCII)).ToString();
                    }

                    break;
                default:
                    break;
            }

            return array;
        }

        public static T[] GetRandomizedArray<T>(int size)
            where T : IComparable
        {
            var random = new Random();
            T[] array = new T[size];

            switch (array.GetType().Name)
            {
                case "Int[]":
                    for (int index = 0; index < size; index++)
                    {
                        var value = random.Next(MinValue, MaxValue);
                        array[index] = (dynamic)value;
                    }

                    break;
                case "Double[]":
                    for (int index = 0; index < size; index++)
                    {
                        var value = random.Next(MinValue, MaxValue) + ConstFraction;
                        array[index] = (dynamic)value;
                    }

                    break;
                case "String[]":
                    for (int index = 0; index < size; index++)
                    {
                        var value = random.Next(FirstLetterCodeASCII, LastLetterCodeASCII);
                        array[index] = (dynamic)((char)value).ToString();
                    }

                    break;
                default:
                    break;
            }

            return array;
        }
    }
}
