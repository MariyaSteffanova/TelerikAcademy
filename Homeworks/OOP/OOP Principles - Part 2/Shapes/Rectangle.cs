namespace Shapes
{
   public class Rectangle : Shape
    {
        public Rectangle(decimal width, decimal height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override decimal CalculateSurface()
        {
            decimal surface = this.Width * this.Height;
            return surface;
        }
    }
}
