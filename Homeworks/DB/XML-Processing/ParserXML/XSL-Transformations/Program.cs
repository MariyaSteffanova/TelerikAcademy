
using System;
using System.IO;
using System.Xml.Xsl;

namespace XSL_Transformations
{
    class Program
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../style.xslt");
            xslt.Transform("../../../Lib/xml/catalogue.xml", "../../catalog.html");
            string curDir = Directory.GetCurrentDirectory();

            System.Diagnostics.Process.Start(Path.GetFullPath("../../catalog.html"));
        }
    }
}
