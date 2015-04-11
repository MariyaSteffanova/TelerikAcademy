using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Unufri");
            var person2 = new Person("Stamat", 21);
            Console.WriteLine(person.ToString());
            Console.WriteLine(person2.ToString());

            Console.WriteLine(Environment.NewLine + "TEST WITH YOUR INPUT:");
            Console.Write("Enter Name:");
            var name = Console.ReadLine();
            Console.Write("Enter age:");
            var age = int.Parse(Console.ReadLine());
            var person3 = new Person(name, age);
            Console.WriteLine(person3.ToString());

            
        }
    }
}
