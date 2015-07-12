namespace Cooking
{
    using System;
    using Cooking.Ingredients;

    public class CookingPoint
    {
        public static void Main()
        {
            var chef = new Chef();
            var bowl = chef.Cook();

            Console.WriteLine(bowl);
        }
    }
}
