namespace People
{
    using System;

   public class People
    {
        public static void Main(string[] args)
        {
            var person = new Person();

            person = person.GeneratePerson(35);
            Console.WriteLine("Name: {0}", person.Name);
            Console.WriteLine("Gender: {0}", person.Gender);
            Console.WriteLine("Age: {0}", person.Age);
        }
    }
}
