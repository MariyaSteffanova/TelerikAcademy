namespace Strategy
{
    using System;

    internal class CalculateTravelCost
    {
        private IVehicle vehicle;
        private decimal distance;

        public CalculateTravelCost(IVehicle vehicle, int distance)
        {
            this.vehicle = vehicle;
            this.distance = distance;
        }

        public void Display()
        {
            Console.WriteLine($"Traveling by { this.vehicle.GetType().Name }");
            Console.WriteLine($"Distance: { this.distance } km.");
            Console.WriteLine($"Travel costs: {this.Calculate() } euro.{ Environment.NewLine }");
        }

        private decimal Calculate()
        {
            return this.vehicle.GetCostPerKilometer() * this.distance;
        }
    }
}