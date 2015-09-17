namespace ChainOfResponsibility
{
    public abstract class Dispenser
    {
        protected Dispenser Successor { get; set; }

        public void SetSuccessor(Dispenser successor)
        {
            this.Successor = successor;
        }

        public abstract void Dispense(Currency currency);
    }
}
