namespace Shapes
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            var shapes = new List<Shape>();
            shapes.Add(new Rectangle(2, 4));
            shapes.Add(new Triangle(4, 4));
            shapes.Add(new Circle(3));            

            shapes.Add(new Rectangle(4, 4));
            shapes.Add(new Triangle(2, 4));
            shapes.Add(new Circle(6));           

            shapes.Add(new Rectangle(5, 6));
            shapes.Add(new Triangle(5, 8));
            shapes.Add(new Circle(9));

            double ind = 0;
            for (int index = 0; index < shapes.Count; index++)
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
