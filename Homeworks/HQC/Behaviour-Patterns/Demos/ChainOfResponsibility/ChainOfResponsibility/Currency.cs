namespace ChainOfResponsibility
{
    public class Currency
    {
        private int amount;

        public Currency(int amount)
        {
            this.amount = amount;
        }

        public int GetAmount()
        {
            return this.amount;
        }
    }
}
