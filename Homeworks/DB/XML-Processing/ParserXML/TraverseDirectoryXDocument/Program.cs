using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TraverseDirectory
{
    class Program
    {
        static void Main()
        {
            var root = "../../../../";

            var document = TraverseDirectory(root);
            document.Save("../../document.xml");


        }

        public static XElement TraverseDirectory(string dir)
        {
            XElement element = new XElement("dir",
                new XAttribute("path", dir)
                );

            var dirs = Directory.GetDirectories(dir);

            foreach (var currentDir in dirs)
            {
                element.Add(TraverseDirectory(currentDir));
            }

            var files = Directory.GetFiles(dir);

            foreach (var file in files)
            {
                element.Add(new XElement("file",
                    new XAttribute("name", Path.GetFileName(file))
                    ));

            }

            return element;
        }

    }
}
