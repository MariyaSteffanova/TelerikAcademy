namespace Abstraction
{
    using System;
    using System.Text;

    public class Rectangle : Figure
    {
        public const string InvalidWidthExMessage = "Width must be a possitive number!";
        public const string InvalidHeightMessage = "Height must be a possitive number!";
        private double width;
        private double height;

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException(Rectangle.InvalidWidthExMessage);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException(Rectangle.InvalidHeightMessage);
                }

                this.height = value;
            }
        }
        
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendFormat("Width: {0:F1}", this.Width).AppendLine();
            result.AppendFormat("Height: {0:F1}", this.Height).AppendLine();

            return result.ToString();
        }
    }
}
