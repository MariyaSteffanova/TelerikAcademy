using System;
using System.IO;
using System.Text;
using System.Xml;

namespace PersonInfoTextToXML
{
    class CreateXML
    {
        static void Main()
        {
            var person = new Person();

            using (StreamReader reader = new StreamReader("../../person.txt"))
            {
                person.Name = reader.ReadLine();
                person.Address = reader.ReadLine();
                person.Phone = reader.ReadLine();
            }

            string fileName = "../../person.xml";
            Encoding encoding = Encoding.GetEncoding("utf-8");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("person");
                writer.WriteElementString("name", person.Name);
                writer.WriteElementString("address", person.Address);
                writer.WriteElementString("phone", person.Phone);

                writer.WriteEndDocument();

            }

            Console.WriteLine("File [ person.xml ] created. {0}", Environment.NewLine);
            Console.WriteLine("Loaded file [ person.xml ] : {0}", Environment.NewLine);
           
            XmlDocument document = new XmlDocument();
            document.Load("../../person.xml");
            Console.WriteLine(document.InnerXml + Environment.NewLine); 
        }
    }
}

