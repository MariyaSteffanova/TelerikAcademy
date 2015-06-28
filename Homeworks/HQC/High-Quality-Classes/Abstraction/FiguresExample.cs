namespace Abstraction
{
    using System;
    using System.Collections.Generic;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(2, 3);

            var figures = new List<IFigure>() { circle, rectangle };

            foreach (IFigure figure in figures)
            {
                Console.WriteLine(figure.ToString());
            }
        }
    }
}
