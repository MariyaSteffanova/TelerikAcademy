using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidianSpace3D
{
    using System.IO;
   public static  class Path
    {
        private static Random pointsGenerator =  new Random();

       
        public static List<Point3D> GeneretePath(int numberOfPoints)
        {
            var path = new List<Point3D>(numberOfPoints);
           
            for (int point = 0; point < numberOfPoints; point++)
            {               
                path.Add(new Point3D(pointsGenerator.Next(1, 20), pointsGenerator.Next(1, 20), pointsGenerator.Next(1, 20)));
            }            
            return path;
        }
        public static void SavePathToStorge( List<Point3D> path)
        {
            var writer = new StreamWriter(@"path.txt");
            using (writer)
            {
                foreach (var point in path)
                {
                    string line = point.X + " " + point.Y + " " + point.Z;
                    writer.WriteLine(line);
                }    
            }
                
        }

        public static List<Point3D> LoadPathFromStorage()
        {
            var path = new List<Point3D>();
            var reader =new  StreamReader(@"path.txt");
            var line = reader.ReadLine();
            using (reader)
            {
                while (line != null)
                {
                    int[] coords = line.Split(' ')
                        .Select(x => int.Parse(x))
                        .ToArray();
                    var point = new Point3D(coords[0], coords[1], coords[2]);
                    path.Add(point);
                    line = reader.ReadLine();
                }
            }
            

            return path;
        }
    }
}
