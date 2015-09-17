namespace ChainOfResponsibility
{
    using System;

    public class Euro50Dispenser : Dispenser
    {
        private readonly int noteValue = 50;
        public override void Dispense(Currency currency)
        {
            int requestAmount = currency.GetAmount();

            if (requestAmount >= this.noteValue)
            {
                int amount = requestAmount / this.noteValue;
                int remainder = requestAmount % this.noteValue;

                Console.WriteLine($"Dispensing : { amount } x {this.noteValue} = {amount * this.noteValue} Euro");

                if (remainder != 0)
                {
                    this.Successor.Dispense(new Currency(remainder));
                }
            }
            else
            {
                this.Successor.Dispense(currency);
            }

        }
    }
}
