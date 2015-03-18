using EuclidianSpace3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidianSpace3D
{

    public class Test
    {
        public static void TestEuclidianSpace()
        {
            var firstPoint = new Point3D();
            //Console.WriteLine("Enter coordinates:");
            //Console.Write("X = ");
            //firstPoint.X = int.Parse(Console.ReadLine());
            //Console.Write("Y = ");
            //firstPoint.Y = int.Parse(Console.ReadLine());
            //Console.Write("Z = ");
            //firstPoint.Z = int.Parse(Console.ReadLine());

            firstPoint.X = 24;
            firstPoint.Y = 6;
            firstPoint.Z = 10;
            Console.WriteLine("CREATE POINT [{0},{1},{2}] :", firstPoint.X, firstPoint.Y, firstPoint.Z);
            Console.WriteLine(firstPoint + Environment.NewLine);
            var secondPoint = Point3D.ZeroPoint;
            Console.WriteLine("CREATE ZERO POINT (Start of the coordination system) :");
            Console.WriteLine(secondPoint + Environment.NewLine);

            // Task 2: You can not modify the value because its readonly
            // Point3D.ZeroPoint.X = 6;       

            // Task 2: You still can't, because VStudio is smart :)
            // Point3D.ZeroPoint.X = int.Parse(Console.ReadLine());  


            double distance = Calculations.CalculateDistance(firstPoint, secondPoint);
            Console.WriteLine("THE DISTANCE BETWEEN FIRST AND SECOND POINT IS: {0:F3}", distance);


            distance = Calculations.CalculateDistance(secondPoint, firstPoint);
            Console.WriteLine("THE DISTANCE BETWEEN SECOND AND FIRST POINT IS: {0:F3}", distance);

            Console.WriteLine("CREATING PATH OF POINTS.." + Environment.NewLine);
            var path = Path.GeneretePath(10);
            Path.SavePathToStorge(path);
            Console.WriteLine(@"A PATH OF POINTS HAS BEEN SAVED IN DIRECTORY:  ..\bin\Debug\path.txt " + Environment.NewLine);
            Console.WriteLine("LOADING PATH FROM FILE.." + Environment.NewLine);
            Console.WriteLine("PATH FROM FILE <path.txt> CONTAINS POINTS:");
            var newPath = Path.LoadPathFromStorage();

            foreach (var point in newPath)
            {
                Console.WriteLine(point.ToString());
            }
        }
       
         
    }
}
