namespace Decorator
{
    using System;

    public abstract class Pancake
    {
        protected string Description { get; set; }
        protected double Calories { get; set; }

        public abstract double CalculateCalories();
        public abstract string GetDescription();
        public void Display()
        {
            Console.WriteLine($"{ this.GetDescription() }{ Environment.NewLine } Calories: { this.CalculateCalories() }");
        }
    }
}
