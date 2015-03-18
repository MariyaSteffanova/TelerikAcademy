namespace AnimalHierarchy
{
    using System;
    public class Dog : Animal
    {
        public Dog()
        { 
        }

        public Dog(int age)
        {
            this.Age = age;
        }

        public Dog(string name, int age, SexEnum sex)
            : this(age)
        {
            this.Name = name;
            this.Sex = sex;
        }

        public override void Talk()
        { 
        Console.WriteLine("Bau");
        }
    }
}
