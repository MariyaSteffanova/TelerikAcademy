using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Problem 6. Divisible by 7 and 3

//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
//Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
namespace DevisibleBy7and3
{
    class DevisibleBy7and3
    {
        static void Main(string[] args)
        {
            // not really sure that the task requires  exactly this :/
            int[] arr = new int[] { 1, 2, 3, 4, 7, 14, 21, 42, 62, 63 };
            var devisibled = from number in arr
                             where number % 3 == 0 && number % 7 == 0
                             select number;
            Console.WriteLine("NUMBERS DEVISIBLE BY 7 AND 3: (using LINQ)");
            Console.WriteLine(string.Join(" ", devisibled));

            Console.WriteLine("NUMBERS DEVISIBLE BY 7 AND 3 (using lambda):");
            int[] devisibled2 = arr.Where(x => x % 3 == 0 && x % 7 == 0).ToArray();
            Console.WriteLine(string.Join(" ", devisibled2));
        }
    }
}
