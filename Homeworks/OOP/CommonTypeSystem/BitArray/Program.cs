namespace BitArray
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WindowWidth = Console.BufferWidth = 120;
            var numbers = new List<BitArray64> { 
                            new BitArray64(5), 
                            new BitArray64(254),
                            new BitArray64(4611686018427387904) };

            foreach (var num in numbers)
            {
                Console.WriteLine("NUMBER IN DECIMAL REPRESENTATION: {0}", num.DecimalRepresentation);
                Console.WriteLine("{0}({1}) = {2}", num.GetType().Name, num.DecimalRepresentation, num);
                Console.WriteLine(new string('-', Console.WindowWidth-1));
            }            

            for (int ind = 0; ind < numbers.Count-1; ind++)
            {
                Console.WriteLine("{0,10} == {1} : {2}",                                             
                                            numbers[ind],                                            
                                            numbers[ind+1],
                                            numbers[ind] == numbers[ind+1]);
                Console.WriteLine("{0,10} != {1} : {2}",
                                            numbers[ind],
                                            numbers[ind + 1],
                                            numbers[ind] != numbers[ind + 1]);
                Console.WriteLine("{0,10}.Equals({1}) : {2}",
                                           numbers[ind],
                                           numbers[ind + 1],
                                           numbers[ind].Equals(numbers[ind + 1]));
                Console.WriteLine();
            }
            Console.WriteLine("TESTING IEnumerator, foreaching BitArray64(5):");
            foreach (var digit in new BitArray64(5))
            {
                Console.Write((char)digit + " ");
            }
            Console.WriteLine();
        }            
    }
}
