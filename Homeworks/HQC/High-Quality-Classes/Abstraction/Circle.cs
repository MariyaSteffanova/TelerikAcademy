namespace Abstraction
{
    using System;
    using System.Text;

    public class Circle : Figure
    {
        private const string InvalidRadiusExMessage = "Radius must be a possitive number!";
        private double radius;

        public Circle()
        {
        }

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException(Circle.InvalidRadiusExMessage);
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendFormat("Radius: {0:F1}", this.Radius).AppendLine();
            return result.ToString();
        }
    }
}
