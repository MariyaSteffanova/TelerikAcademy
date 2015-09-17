namespace Decorator
{
    public class AgaveDecorator : PancakeDecorator
    {
        public AgaveDecorator(Pancake pancake)
            : base(pancake)
        {
        }

        public override double CalculateCalories()
        {
            return this.Pancake.CalculateCalories() + 20.6;
        }

        public override string GetDescription()
        {
            return this.Pancake.GetDescription() + "\n\t + agave syrup;";
        }
    }
}
