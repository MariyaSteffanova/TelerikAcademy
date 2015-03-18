namespace AnimalHierarchy
{
    using System;
    using System.Linq;
    public class Program
    {
        static void Main(string[] args)
        {
            // TODO: constructors (i need that for the age )
            // TODO: Some useless methods in each child of Animal
            // TODO: some animals in array
            // TODO: calc avrg age 
            // TODO: Test Cats sex
            var cat = new Cat(15);
            var cat2 = new Cat(1);
            var cat3 = new Cat(5);
            var cat4 = new Cat(7);
            Cat[] catArr = new Cat[] { cat, cat2, cat3, cat4 };
            var averageCatAge = catArr.Average(x => x.Age);
            Console.Write("AGE OF CATS:  ");
            foreach (var catMember in catArr)
            {
                Console.Write(catMember.Age + " ");
            }
            Console.Write(Environment.NewLine + "AVERAGE CAT'S AGE:");
            Console.WriteLine(averageCatAge + Environment.NewLine);

            var dog = new Dog(8);
            var frog = new Frog(3);
            var kitty = new Kittens(4);
            var tom = new Tomcat(6);
            var justAnimal = new Animal("Unufri", 3, Animal.SexEnum.Male);
            Animal[] animals = new Animal[] { cat, dog, frog, kitty, tom , justAnimal};
            Console.WriteLine("ANIMALS AGES:");
            foreach (var animal in animals)
            {
                Console.WriteLine("{0,13} age is: {1}", "Some " + animal.GetType().Name, animal.Age);
            }
            var averageAnimalAge = animals.Average(x => x.Age);
            Console.Write("AVERAGE ANIMAL'S AGE:");
            Console.WriteLine(averageAnimalAge + Environment.NewLine);
            Console.WriteLine("{0} sex is: {1}", kitty.GetType().Name, kitty.Sex);
            Console.WriteLine("{0} sex is: {1}", tom.GetType().Name, tom.Sex);

            Console.WriteLine(Environment.NewLine);
            Console.Write("KITTENS CAT PRODUCE SOUND: ");
            kitty.Talk();
            Console.Write("TOMCATS CAN PRODUCE SOUND: ");
            tom.Talk();
            Console.Write("ALL CATS CAN PRODUCE SOUND: ");
            cat.Talk();
            Console.Write("DOGS CAN PRODUCE SOUND: ");
            dog.Talk();
            Console.Write("FROGS CAN PRODUCE SOUND: ");
            frog.Talk();
            Console.WriteLine("ALL ANIMALS CAN PRODUCE SOUND, BUT THEY HAVE TO KNOW WHAT KINDOF ANIMAL ARE: ");            
            justAnimal.Talk();
            Console.WriteLine();
        }
    }
}
