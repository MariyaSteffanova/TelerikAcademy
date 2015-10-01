using System;
using System.Linq;
using System.Xml.Linq;

namespace AlbumPriceExtractorLINQ
{
    class Program
    {
        static void Main()
        {
            XDocument document = XDocument.Load("../../../Lib/xml/catalogue.xml");
            var albums =
                from album in document.Descendants("album")
                where int.Parse(album.Element("year").Value) < 2010
                select new
                {
                    Name = album.Element("name").Value,
                    Year = album.Element("year").Value
                };

            foreach (var album in albums)
            {
                Console.WriteLine("Album: {0} | Year: {1}", album.Name, album.Year);
            }
        }
    }
}
