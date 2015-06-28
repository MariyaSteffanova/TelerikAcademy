namespace Abstraction
{
    using System;
    using System.Text;

    public abstract class Figure : IFigure
    {
        public Figure()
        {
        }

        public abstract double CalcSurface();        

        public abstract double CalcPerimeter();

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("Figure: {0}", this.GetType().Name);
            result.AppendLine();
            result.AppendFormat("Surface: {0:F3}", this.CalcSurface());
            result.AppendLine();
            result.AppendFormat("Perimeter: {0:F3}", this.CalcPerimeter());
            result.AppendLine();

            return result.ToString();
        }
    }
}
