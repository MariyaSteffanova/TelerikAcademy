namespace Decorator
{
    public abstract class PancakeDecorator : Pancake
    {
        public PancakeDecorator(Pancake pancake)
        {
            this.Pancake = pancake;
        }

        protected Pancake Pancake { get; set; }
    }
}
