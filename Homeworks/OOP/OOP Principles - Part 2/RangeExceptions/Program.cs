namespace RangeExceptions
{
    using System;
    class Program
    {
        static void Main()
        {
            const int startRangeInt = 1;
            const int endRangeInt = 100;
            DateTime startRangeDate = DateTime.Parse("1.1.1980");
            DateTime endRangeDate = DateTime.Parse("31.12.2013");

            int[] test = new int[]{92, 102, 0};
            for (int index = 0; index < test.Length; index++)
            {
                try
                {
                    if (test[index] < startRangeInt || test[index] > endRangeInt) 
                        throw new InvalidRangeException<int>(test[index]);
                    Console.WriteLine(test[index]);
                }

                catch (InvalidRangeException<int> ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            var testDate = new DateTime[]{ DateTime.Parse("20.12.2014"), DateTime.Parse("21.03.2011") };
            for (int index = 0; index < testDate.Length; index++)
            {
                try
                {
                    if (testDate[index] < startRangeDate || testDate[index] > endRangeDate) 
                        throw new InvalidRangeException<DateTime>(testDate[index]);
                    Console.WriteLine("{0:dd.MM.yyyy}",testDate[index]);
                }

                catch (InvalidRangeException<DateTime> ex)
                {
                    Console.WriteLine(ex.Message);                   
                }                
            }
        }
    }
}
