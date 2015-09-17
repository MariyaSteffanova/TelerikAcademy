namespace ChainOfResponsibility
{
    class Client
    {
        static void Main(string[] args)
        {
            var amount = new Currency(333);
            var dispenser = new Euro50Dispenser();
            var dispenser20Euro = new Euro20Dispenser();
            var dispenser10Euro = new Euro10Dispenser();
            dispenser.SetSuccessor(dispenser20Euro);
            dispenser20Euro.SetSuccessor(dispenser10Euro);

            dispenser.Dispense(amount);
        }
    }
}
