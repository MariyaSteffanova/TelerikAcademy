namespace Decorator
{
    public class WholeGrainPancake : Pancake
    {

        public WholeGrainPancake()
        {
            this.Calories = 50;
            this.Description = "Healthy whole grain pancake!";
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
