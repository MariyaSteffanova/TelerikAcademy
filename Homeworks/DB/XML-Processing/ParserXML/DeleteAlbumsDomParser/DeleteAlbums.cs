using System;
using System.Collections.Generic;
using System.Xml;

namespace DeleteAlbumsDomParser
{
    class DeleteAlbums
    {
        static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../../Lib/xml/catalogue.xml");
            XmlNode root = document.DocumentElement;
            DeleteAlbumsByPrice(root, 20.00);
            document.Save("../../updatedCatalogue.xml");

        }

        private static void DeleteAlbumsByPrice(XmlNode root, double maxPrice)
        {
            var nodesToRemove = new List<XmlNode>();

            foreach (XmlNode album in root.ChildNodes)
            {
                var price = double.Parse(album["price"].InnerText);

                if(price > maxPrice)
                {
                   nodesToRemove.Add(album);                    
                }
            }

            foreach (var album in nodesToRemove)
            {
                root.RemoveChild(album);
            }
        }
    }
}
