using System.Text;
using System.Xml;

namespace AlbumsInfoExtraxtor
{
    class Program
    {
        static void Main()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.Encoding = Encoding.UTF8;
            xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;

            using (XmlWriter writer = XmlWriter.Create("../../albums.xml", xmlWriterSettings))
            {
                              
                using (XmlReader reader = XmlReader.Create("../../../Lib/xml/catalogue.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "name")
                            {
                                writer.WriteStartElement("album");
                                writer.WriteElementString("name", reader.ReadInnerXml());
                            }
                            else if (reader.Name == "artist")
                            {
                                writer.WriteElementString("artist", reader.ReadInnerXml());
                                writer.WriteEndElement();
                            }
                        }
                    }
                }
            }
        }
    }
}
