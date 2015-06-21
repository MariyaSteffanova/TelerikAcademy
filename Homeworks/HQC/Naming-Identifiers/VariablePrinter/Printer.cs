namespace VariablePrinter
{
    using System;

    public class Printer
    {
        public class BooleanPrinter
        {
            public void PrintBoolean(bool value)
            {
                string valueAsString = value.ToString();
                Console.WriteLine(valueAsString);
            }
        }
    }
}
