namespace AnimalHierarchy
{
    using System;

   public class Cat : Animal
    {
       private bool isAsleep = false;

       public Cat()
       { 
       }

       public Cat(int age)
       {
           this.Age = age;
       }

       public Cat(string name, int age, SexEnum sex) : this(age)
       {
           this.Name = name;
           this.Sex = sex;
       }

        public override void Talk() 
       {
          Console.WriteLine("Meow");
       }

       public void Sleep()
       {
           this.isAsleep = true;
           Console.WriteLine("Mrr");
       }
    }
}
