namespace AnimalHierarchy
{
    using System;

    public class Frog : Animal
    {
        public Frog()
        {
        }

        public Frog(int age)
        {
            this.Age = age;
        }

        public Frog(string name, int age, SexEnum sex)
            : this(age)
        {
            this.Name = name;
            this.Sex = sex;
        }

        public override void Talk()
        {
            Console.WriteLine("Croak");
        }
    }
}
