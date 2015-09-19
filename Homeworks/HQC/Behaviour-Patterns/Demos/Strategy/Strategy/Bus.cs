namespace Strategy
{
    internal class Bus : IVehicle
    {
        private int passengers;
        private decimal costPerKilometer;

        public Bus(int passengers)
        {
            this.passengers = passengers;
            this.costPerKilometer = 3.6m;
        }

        public decimal GetCostPerKilometer()
        {
            return this.costPerKilometer / this.passengers;
        }
    }
}