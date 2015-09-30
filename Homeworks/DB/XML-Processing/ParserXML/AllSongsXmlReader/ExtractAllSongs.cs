namespace AllSongsXmlReader
{
    using System;
    using System.Xml;

    class ExtractAllSongs
    {
        static void Main()
        {
            Console.WriteLine("List of all songs from Catalogue: {0}{1}", Environment.NewLine, new string('-',42));
            using (XmlReader reader = XmlReader.Create("../../../Lib/xml/catalogue.xml"))
            {
               
                while (reader.Read())
                {
                    if(reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                    
                }
            }
        }
    }
}
