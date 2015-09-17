namespace Decorator
{
    public class ChocolateDecorator : PancakeDecorator
    {
        public ChocolateDecorator(Pancake pancake)
            : base(pancake)
        {
        }

        public override double CalculateCalories()
        {
            return this.Pancake.CalculateCalories() + 55.50;
        }

        public override string GetDescription()
        {
            return this.Pancake.GetDescription() + "\n\t + chocolate;";
        }
    }
}
