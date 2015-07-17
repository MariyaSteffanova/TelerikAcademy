namespace Methods
{
    using System;

    public class TestMethods
    {
        public static void Main()
        {
            Console.WriteLine(Calculate.TriangleArea(3, 4, 5));

            Console.WriteLine(NumberExtensions.TranslateDigitToWord(5));

            Console.WriteLine(ArrayExtensions.FindMax(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine(NumberExtensions.FormatNumber(1.3, "f"));
            Console.WriteLine(NumberExtensions.FormatNumber(0.75, "%"));
            Console.WriteLine(NumberExtensions.FormatNumber(2.30, "r"));

            Console.WriteLine(Calculate.Distance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + PositionChecker.IsHorizontal(-1, 2.5));
            Console.WriteLine("Vertical? " + PositionChecker.IsVertical(3, 3));

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
