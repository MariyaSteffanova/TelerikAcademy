using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidianSpace3D
{
    public struct Point3D   // Task 1
    {
        private static readonly Point3D StartCoordSys = new Point3D(0, 0, 0);

        private static readonly int zero = 0;

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }


        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public static Point3D ZeroPoint
        {
            get
            {
                return StartCoordSys;
            }

        }
        public override string ToString()
        {
            var coords = string.Format("[X: {0,-3}, Y: {1,-3}, Z:{2,-3}]", this.X, this.Y, this.Z);
            return coords;
        }
        public string Paint()
        {
            Console.SetCursorPosition(this.X, this.Y);
            return ".";
        }
    }
}
