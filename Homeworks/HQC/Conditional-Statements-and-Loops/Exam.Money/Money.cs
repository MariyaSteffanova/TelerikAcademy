namespace Exam_Money
{
    using System;

    public class Money
    {
        private const decimal SheetsPerBox = 400;

        public static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int sheetsPerStudent = int.Parse(Console.ReadLine());
            decimal priceOfBoxSheets = decimal.Parse(Console.ReadLine());

            decimal usedSheets = studentsCount * sheetsPerStudent;
            decimal boxSheets = usedSheets / SheetsPerBox;

            decimal amount = boxSheets * priceOfBoxSheets;
            Console.WriteLine("{0:F3}", amount);
        }
    }
}
