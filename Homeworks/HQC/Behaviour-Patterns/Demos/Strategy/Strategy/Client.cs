namespace Strategy
{
   public  class Client
    {
        static void Main()
        {
            IVehicle car = new Car();
            IVehicle bus = new Bus(40);

            var costByCar = new CalculateTravelCost(car, 400);
            var costByBus = new CalculateTravelCost(bus, 400);

            costByCar.Display();
            costByBus.Display();
        }
    }
}
