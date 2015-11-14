namespace _01.BinaryPasswords
{
    using System;
    using System.Linq;

    class StartUp
    {
        // 268435456   2 ^ 60
        // 2147483647  int.max
        static void Main()
        {
            int input = Console.ReadLine().Where(x => x == '*').Count();
            Console.WriteLine((long)1 << input);
           
        }
    }
}
