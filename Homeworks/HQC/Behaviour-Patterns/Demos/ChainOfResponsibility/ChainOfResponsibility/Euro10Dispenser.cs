namespace ChainOfResponsibility
{
    using System;

    public class Euro10Dispenser : Dispenser
    {
        private readonly int noteValue = 10;

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
                    Console.WriteLine($"ATM Error: Amount should be multiple of 10. Remainder from your request: {remainder} euros ( redirected to your account).");
                }
            }
            else
            {
                Console.WriteLine("ATM Error: Amount should be multiple of 10.");
            }
        }
    }
}
