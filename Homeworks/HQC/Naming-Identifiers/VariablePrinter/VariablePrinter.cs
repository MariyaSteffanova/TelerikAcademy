namespace VariablePrinter
{
    using System;

    public class VariablePrinter
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            var boolPrinter = new Printer.BooleanPrinter();
            boolPrinter.PrintBoolean(true);
        }
    }
}
