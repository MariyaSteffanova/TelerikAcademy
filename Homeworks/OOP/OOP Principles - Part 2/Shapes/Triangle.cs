namespace Shapes
{
    public class Triangle : Shape
    {
        public Triangle(decimal width, decimal height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override decimal CalculateSurface()
        {
            decimal surface = (this.Width * this.Height) / 2;
            return surface;
        }
    }
}
