namespace Shapes
{
    using System;

    public class Program
    {
        static void Main()
        {
            var rectangleFirst = new Rectangle(2, 4);
            var rectangleSecond = new Rectangle(4, 4);
            var rectangleThird = new Rectangle(5, 6);

            var triangleFirst = new Triangle(2, 4);
            var triangleSecond = new Triangle(4, 4);
            var triangleThird = new Triangle(5, 8);

            var circleFirst = new Circle(3);
            var circleSecond = new Circle(6);
            var circleThird = new Circle(9);

            Shape[] shapes = new Shape[]{ 
                             rectangleFirst,  triangleFirst,  circleFirst,
                             rectangleSecond, triangleSecond, circleSecond,
                             rectangleThird,  triangleThird,  circleThird };
            double ind = 0;
            for (int index = 0; index < shapes.Length; index++)
            {
                ind += 0.3;
                int numeration = 1 + (int)ind;
                decimal surface = shapes[index].CalculateSurface();
                Console.WriteLine("SURFACE of {0,2} {1,-9}: {2,6:F2}",
                    numeration == 1 ? string.Format("{0}st", numeration) :
                    numeration == 2 ? string.Format("{0}nd", numeration) :
                     string.Format("{0}rd", numeration),
                     shapes[index].GetType().Name.ToUpper(), surface);
            }
        }
    }
}
