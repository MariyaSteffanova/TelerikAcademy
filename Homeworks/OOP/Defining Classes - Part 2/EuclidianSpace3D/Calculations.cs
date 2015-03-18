using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidianSpace3D
{
    static class Calculations
    {
    //xd = x2-x1
    //yd = y2-y1
    //zd = z2-z1
    //Distance = SquareRoot(xd*xd + yd*yd + zd*zd)
       public static double CalculateDistance(Point3D first, Point3D second)
        {
            double distance = 0.0;
            double xD = second.X-first.X;
            double yD = second.Y - first.Y;
            double zD = second.Z - first.Z;

            distance =Math.Sqrt(xD * xD + yD * yD + zD * zD);
            return distance;
        }
    }
}
