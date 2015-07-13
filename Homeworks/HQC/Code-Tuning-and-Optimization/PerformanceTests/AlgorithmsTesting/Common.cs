namespace AlgorithmsTesting
{
    using System;

    public static class Common
    {
        private const int ArraySize = 100;
        private const int MinValue = -300;
        private const int MaxValue = 300;

        public static int[] GetReversedArray()
        {
            int[] array = new int[ArraySize];
            for (int index = ArraySize-1; index > 0; index--)
            {
                array[index] = index;
            }

            return array;
        }

        public static int[] GetSortedArray()
        {
            int[] array = new int[ArraySize];

            for (int index = 0; index < ArraySize; index++)
            {
                array[index] = index;
            }

            return array;
        }

        public static int[] GetRandomizedArray()
        {
            var random = new Random();
            var array = new int[ArraySize];
            for (int index = 0; index < ArraySize; index++)
            {
                array[index] = random.Next(MinValue, MaxValue);
            }

            return array;
        }
    }
}
