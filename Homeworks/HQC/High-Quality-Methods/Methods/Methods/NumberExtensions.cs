namespace Methods
{
    using System;

    public class NumberExtensions
    {      
        public static string TranslateDigitToWord(int number)
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
               
        public static string FormatNumber(object number, string format)
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
    }
}