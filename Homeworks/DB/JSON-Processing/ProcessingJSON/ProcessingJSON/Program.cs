namespace ProcessingJSON
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections;
    using System.Xml.Linq;
    using System.Xml.Xsl;
    using System.IO;

    class Program
    {
        private const string XML_PATH = "../../ta-rss.xml";
        private const string HTML_PATH = "../../ta-rss.html";
        private const string XSLT_PATH = "../../rss-style.xslt";
        private const string RSS_URI = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

        static void Main()
        {
            string xml = DownloadRssData();

            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);

            string json = JsonConvert.SerializeXmlNode(document, Newtonsoft.Json.Formatting.Indented);

            JObject jsonObj = JObject.Parse(json);

            // Task 4.
            PrintVideoTitlesOnConsole(jsonObj);

            IEnumerable<Video> videos = GetVideos(jsonObj);

            SaveVideoInfoAsXml(XML_PATH, videos);

            CrateHtml(XML_PATH, HTML_PATH, XSLT_PATH);

            OpenHtmlInDefaultBrowser(HTML_PATH);

        }

        private static void PrintVideoTitlesOnConsole(JObject jsonObj)
        {
            IEnumerable<JToken> titles = jsonObj["feed"]["entry"]
                          .Select(entry => entry["title"]);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static string DownloadRssData()
        {
            var webClient = new WebClient();
            var data = webClient.DownloadData(RSS_URI);
            var xml = Encoding.UTF8.GetString(data);
            return xml;
        }

        private static void OpenHtmlInDefaultBrowser(string htmlPath)
        {
            string curDir = Directory.GetCurrentDirectory();
            System.Diagnostics.Process.Start(Path.GetFullPath(htmlPath));
        }

        private static void CrateHtml(string xmlPath, string htmlPath, string xsltPath)
        {
            XslCompiledTransform xslt = new XslCompiledTransform(true);
            xslt.Load(xsltPath);

            xslt.Transform(xmlPath, htmlPath);
        }

        private static void SaveVideoInfoAsXml(string xmlPath, IEnumerable<Video> videos)
        {
            // TODO: http://www.youtube.com/embed/LWZP5S8U7Z0 convert url to this form form http://www.youtube.com/watch?v=-R6aeupYHMQ

            using (XmlTextWriter writer = new XmlTextWriter(xmlPath, Encoding.UTF8))
            {
                writer.WriteStartElement("videos");
                foreach (var video in videos)
                {
                    writer.WriteStartElement("video");

                    writer.WriteElementString("title", video.Title);
                    writer.WriteElementString("url", video.Url.Href.Replace("watch?v=", "embed/"));

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        private static IEnumerable<Video> GetVideos(JObject jsonObj)
        {
            return jsonObj["feed"]["entry"]
                 .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()));
        }


    }
}
