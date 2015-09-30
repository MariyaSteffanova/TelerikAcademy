namespace AllSongsQueryLINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class ExtractAllSongs
    {
        static void Main()
        {
            XDocument document =  XDocument.Load("../../../Lib/xml/catalogue.xml");

            var songsTitlesCollection =
                from song in document.Descendants("song")
                select  song.Element("title").Value;
            
            Console.WriteLine("List of all songs from Catalogue: {0}{1}", Environment.NewLine, new string('-', 42));

            foreach (var songName in songsTitlesCollection)
            {
                Console.WriteLine(songName);
            }
                 


        }
    }
}
