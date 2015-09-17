namespace Decorator
{
    public class BananaDecorator : PancakeDecorator
    {
        public BananaDecorator(Pancake pancake)
            : base(pancake)
        {
        }

        public override double CalculateCalories()
        {
            return this.Pancake.CalculateCalories() + 33.30;
        }

        public override string GetDescription()
        {
            return this.Pancake.GetDescription() + "\n\t + banana;";
        }
    }
}
