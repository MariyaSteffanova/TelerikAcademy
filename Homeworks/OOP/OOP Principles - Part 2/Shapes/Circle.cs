namespace Shapes
{
    using System;

   public class Circle : Shape
    {
        public Circle(decimal radius)
        {
            this.Width = radius;
        }

        public override decimal CalculateSurface()
        {
            decimal surface = (decimal)Math.PI * (this.Width * this.Width);
            return surface;
        }
    }
}