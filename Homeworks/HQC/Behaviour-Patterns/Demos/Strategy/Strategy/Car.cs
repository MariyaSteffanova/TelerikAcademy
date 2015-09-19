namespace Strategy
{
    internal class Car : IVehicle
    {
        private decimal costPerKilometer;

        public Car()
        {
            this.costPerKilometer = 0.2m;
        }
        public decimal GetCostPerKilometer()
        {
            return this.costPerKilometer;
        }
    }
}