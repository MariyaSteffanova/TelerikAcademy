using System;
using System.IO;
using System.Text;
using System.Xml;

namespace TraverseDirectory
{
    class Program
    {
        static void Main()
        {
            var root = "../../../../";
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.Encoding = Encoding.UTF8;
            xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;

            using (XmlWriter writer = XmlWriter.Create("../../directories.xml", xmlWriterSettings))
            {
                TraverseDirectory(root, writer);
                
            }
        }

        public static void TraverseDirectory(string dir, XmlWriter writer)
        {
            writer.WriteStartElement("dir", dir);
            var dirs = Directory.GetDirectories(dir);
           
           

            foreach (var currentDir in dirs)
            {
                writer.WriteStartElement("dir",currentDir);
                var files = Directory.GetFiles(currentDir);

                foreach (var file in files)
                {
                    writer.WriteStartElement("file", file);
                    writer.WriteFullEndElement();
                       
                }
                
                writer.WriteEndElement();
                TraverseDirectory(currentDir, writer);
            }
          
        }

    }
}
