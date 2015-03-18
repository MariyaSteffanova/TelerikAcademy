using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Problem 1. StringBuilder.Substring

//Implement an extension method Substring(int index, int length) for the class StringBuilder that 
//returns new StringBuilder and has the same functionality as Substring in the class String.
namespace StringBuilderSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var sbTest = new StringBuilder();
            sbTest.Append("123456789012345678");
            var newSb = sbTest.Substring(4, 4);
            Console.WriteLine(newSb.ToString());

        }
    }
}
