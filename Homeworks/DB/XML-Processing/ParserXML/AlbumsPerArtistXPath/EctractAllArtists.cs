namespace AlbumsPerArtistXPath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml;

    class EctractAllArtists
    {
        static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../../Lib/xml/catalogue.xml");
            string xPathQuery = "/catalogue/album/artist";
            XmlNodeList artists = document.SelectNodes(xPathQuery);

            var artistsAndAlbums = CountAlbumsPerArtist(artists);

            foreach (var pair in artistsAndAlbums)
            {
                Console.WriteLine("Artist: {0} : {1} {2}", pair.Key, pair.Value, pair.Value == 1 ? "album" : "albums");
            }


        }
        private static Dictionary<string, int> CountAlbumsPerArtist(IEnumerable artists)
        {
            var artistsAndAlbums = new Dictionary<string, int>();

            foreach (XmlNode artist in artists)
            {
                var artistName = artist.InnerText;

                if (artistsAndAlbums.ContainsKey(artistName))
                {
                    artistsAndAlbums[artistName] += 1;
                }
                else
                {
                    artistsAndAlbums.Add(artistName, 1);
                }
            }

            return artistsAndAlbums;
        }
    }
}
