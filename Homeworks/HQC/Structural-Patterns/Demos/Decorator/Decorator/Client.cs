namespace Decorator
{
    using System;

    public class Client
    {
        static void Main()
        {
            var pancake = new WholeGrainPancake();
            var pancakeWithChocolate = new ChocolateDecorator(pancake);
            var pancakeWithChocolateAndBanana = new BananaDecorator(pancakeWithChocolate);

            pancakeWithChocolateAndBanana.Display();

            Console.WriteLine(new string('=', 40));

            var glutenFreePancake = new GlutenFreePancake();
            var glutenFreePancakeWithBanana = new BananaDecorator(glutenFreePancake);
            var glutenFreePancakeWithBananaAndAgave = new AgaveDecorator(glutenFreePancakeWithBanana);

            glutenFreePancakeWithBananaAndAgave.Display();
        }
    }
}
