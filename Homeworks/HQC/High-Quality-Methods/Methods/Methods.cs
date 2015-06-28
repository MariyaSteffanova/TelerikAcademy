﻿namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");

                // Changes stand for: loose coupling with Console; avoid returns of invalid data (area: -1)
                // Previous code: 
                // Console.Error.WriteLine("Sides should be positive.");
                // return -1;
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentException("Invalid number!");
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Input is empty!");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static string PrintAsNumber(object number, string format)
        {
            // Returning value changed to 'string' instead of directly printig to the console,
            // so the method can be reused in apps not using console

            if (format == "f")
            {
                return string.Format("{0:f2}", number);
            }

            if (format == "%")
            {
                return string.Format("{0:p0}", number);
            }

            if (format == "r")
            {
                return string.Format("{0,8}", number);
            }

            throw new ArgumentException();
        }

        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);
            return isHorizontal;
        }

        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = (x1 == x2);
            return isVertical;
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            // Refactoring to three different methods: IsVertical(), IsHorizontal, CalcDistance(), 
            // each responsible only for its own job
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontal(-1, 2.5));
            Console.WriteLine("Vertical? " + IsVertical(3, 3));

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
