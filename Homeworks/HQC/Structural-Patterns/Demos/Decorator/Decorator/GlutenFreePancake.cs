namespace Decorator
{
    public class GlutenFreePancake : Pancake
    {
        public GlutenFreePancake()
        {
            this.Calories = 40;
            this.Description = "Gluten-free pancake!";
        }

        public override double CalculateCalories()
        {
            return this.Calories;
        }

        public override string GetDescription()
        {
            return this.Description;
        }
    }
}
