namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static T Sum<T>(this IEnumerable<T> a)
        {
            T sum = default(T);
            foreach (var item in a)
            {
                sum += (dynamic)item;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> a)
        {
            T product = default(T) + (dynamic)1;

            try
            {
                foreach (var item in a)
                {
                    product *= (dynamic)item;
                }
            }
            catch (Exception)
            {
                Console.Write("{0} does not have product value", a.GetType().Name);
            }

            return product;
        }

        public static T Max<T>(this IEnumerable<T> a) where T : IComparable<T>
        {
            // a.Compare(3)
            // a = 2, -1
            // a = 3,  0
            // a = 4,  1
            a.OrderBy(x => x);
            T max = default(T);
            foreach (var item in a)
            {
                if (item.CompareTo(max) >= 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Min<T>(this IEnumerable<T> a) where T : IComparable<T>
        {
            T min = a.First();
            foreach (var item in a)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Average<T>(this IEnumerable<T> a)
        {
            T avrg = default(T);
            try
            {
                avrg = a.Sum() / (dynamic)a.Count();
            }
            catch (Exception)
            {
                Console.Write("{0} does not have average value", a.GetType().Name);
            }

            return avrg;
        }
    }
}
