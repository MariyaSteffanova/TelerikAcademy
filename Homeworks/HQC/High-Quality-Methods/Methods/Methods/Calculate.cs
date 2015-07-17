namespace Methods
{
    using System;

    public class Calculate
    {
        public static double TriangleArea(double a, double b, double c)
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

        public static double Distance(double x1, double y1, double x2, double y2)
        {
            // Refactoring to three different methods: IsVertical(), IsHorizontal, CalcDistance(), 
            // each responsible only for its own job
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }
    }
}
