namespace AlgorithmsTesting
{
    using System;
    using System.Collections;
       
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
            T[] collection = new T[size];
            switch (collection.GetType().Name)
            {
                case "Int32[]":

                    for (int index = 0; index < size; index++)
                    {
                        collection[index] = (dynamic)(size - index - 1);
                    }

                    break;
                case "Double[]":
                    for (int index = 0; index < size; index++)
                    {
                        collection[index] = (dynamic)size - index - ConstFraction;
                    }

                    break;
                case "String[]":
                    for (int index = 0; index < size; index++)
                    {
                        collection[index] = (dynamic)((char)(size - index - 1 + FirstLetterCodeASCII)).ToString();
                    }

                    break;
                default:
                    break;
            }

            return collection;
        }

        public static T[] GetSortedArray<T>(int size)
            where T : IComparable
        {
            T[] collection = new T[size];
            switch (collection.GetType().Name)
            {
                case "Int32[]":
                    for (int index = 0; index < collection.Length; index++)
                    {
                        collection[index] = (dynamic)index;
                    }

                    break;
                case "Double[]":
                    for (int index = 0; index < collection.Length; index++)
                    {
                        collection[index] = (dynamic)index + ConstFraction;
                    }

                    break;

                case "String[]":
                    for (int index = 0; index < collection.Length; index++)
                    {
                        collection[index] = (dynamic)((char)(index + FirstLetterCodeASCII)).ToString();
                    }

                    break;
                default:
                    break;
            }

            return collection;
        }

        public static T[] GetRandomizedArray<T>(int size)
            where T : IComparable
        {
            var random = new Random();
            T[] collection = new T[size];

            switch (collection.GetType().Name)
            {
                case "Int32[]":
                    for (int index = 0; index < size; index++)
                    {
                        var value = random.Next(MinValue, MaxValue);
                        collection[index] = (dynamic)value;
                    }

                    break;
                case "Double[]":
                    for (int index = 0; index < size; index++)
                    {
                        var value = random.Next(MinValue, MaxValue) + ConstFraction;
                        collection[index] = (dynamic)value;
                    }

                    break;
                case "String[]":
                    for (int index = 0; index < size; index++)
                    {
                        var value = random.Next(FirstLetterCodeASCII, LastLetterCodeASCII);
                        collection[index] = (dynamic)((char)value).ToString();
                    }

                    break;
                default:
                    break;
            }

            return collection;
        }
    }
}
