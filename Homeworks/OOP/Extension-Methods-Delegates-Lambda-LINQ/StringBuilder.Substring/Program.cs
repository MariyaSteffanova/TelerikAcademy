//// Problem 1. StringBuilder.Substring

//Implement an extension method Substring(int index, int length) for the class StringBuilder that 
//returns new StringBuilder and has the same functionality as Substring in the class String.
namespace StringBuilderSubstring
{
    using System;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            var sbTest = new StringBuilder();
            sbTest.Append("This is test of extension method Substring(int index, int length) for the class StringBuilder");
            Console.WriteLine(sbTest.ToString());
            int index = 7;
            int lenght = 35;
            var newSb = sbTest.Substring(index, lenght);
            Console.WriteLine();
            Console.WriteLine("Substring from index [{0}] with lenght [{1}]: {2}", index, lenght, newSb.ToString());
        }
    }
}
