using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XsdSchema
{
    class Program
    {
        static void Main()
        {
            XDocument xml = XDocument.Load("../../../Lib/xml/catalogue.xml");
            XDocument invalidXml = XDocument.Load("../../../Lib/xml/invalid-catalogue.xml");

            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "../../catalogue.xsd");

            TestAgainstSchema(xml, schema, "catalogue.xml");
            TestAgainstSchema(invalidXml, schema, "invalid-catalogue.xml");
        }

        private static void TestAgainstSchema(XDocument xml, XmlSchemaSet schema, string fileName)
        {
            var msg = string.Empty;
            xml.Validate(schema, (obj, e) =>
            {
                msg = $"{Environment.NewLine}Messagge:  {e.Message }";

            });
            msg = string.Format("Document {0} valid {1}", msg == string.Empty ? "is" : "is not", msg);
            Console.WriteLine("{0,-25}  : {1}{2}", fileName, msg, Environment.NewLine);

        }
    }
}
