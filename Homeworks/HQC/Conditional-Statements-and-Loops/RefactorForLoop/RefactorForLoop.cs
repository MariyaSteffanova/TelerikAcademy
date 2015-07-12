namespace RefactorForLoop
{
    using System;

    public static class RefactorForLoop
    {
        public static void Main()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            numbers.TryFind(3);

            var letters = new char[] { 'h', 'q', 'c', 't', 'a' };
            letters.TryFind('t');
        }

        public static void TryFind<T>(this T[] elements, T expectedValue)
            where T : IComparable
        {
            bool isFound = false;

            for (int index = 0; index < elements.Length; index++)
            {
                T currentElement = elements[index];

                if (elements[index].CompareTo(expectedValue) >= 0)
                {
                    isFound = true;
                    break;
                }

                Console.WriteLine(elements[index]);
            }

            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
