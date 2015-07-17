namespace Methods
{
    using System;

    public class ArrayExtensions
    {
        public static T FindMax<T>(params T[] elements)
           where T : IComparable
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Input is empty!");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i].CompareTo(elements[0]) > 0)
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }
    }
}