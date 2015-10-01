using System;
using System.Xml;

namespace AlbumPriceExtractor
{
    class Program
    {
        static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../../Lib/xml/catalogue.xml");
            string xPathQuery = "catalogue/album[year<2010]";
            XmlNodeList oldAlbums = document.SelectNodes(xPathQuery);

            foreach (XmlNode album in oldAlbums)
            {
                var albumName = album.SelectSingleNode("name").InnerText;
                var albumYear = album.SelectSingleNode("year").InnerText;
                Console.WriteLine("Album: {0} | Year: {1}", albumName, albumYear);
            }

        }
    }
}
