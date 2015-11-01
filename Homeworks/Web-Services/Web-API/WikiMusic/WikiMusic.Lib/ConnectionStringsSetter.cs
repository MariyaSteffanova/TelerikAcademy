namespace WikiMusic.Lib
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml;

    /// <summary>
    /// Creates connection string depending on the client's server intsances. 
    /// </summary>
    public class ConnectionStringsSetter
    {
        private const string EXPRESS = "Express";
        private const string DATA_SOURCE_EXPRESS = @".\SQLEXPRESS";
        private const string DATA_SOURCE_MSSQL = @".\";
        private const string CONNECTION_STRING_FORMAT = "Data Source={0};Initial Catalog={1};Integrated Security={2}";

        public ConnectionStringsSetter(string databaseName, bool integratedSecurity)
        {
            this.DatabaseName = databaseName;
            this.IntegratedSecurity = integratedSecurity;
            this.ServerInstances = new ClientServerInfo().Servers;
            this.ConnectionString = this.CreateConnectionString();
        }

        public string DatabaseName { get; set; }

        public bool IntegratedSecurity { get; set; }

        public string[] ServerInstances { get; set; }

        public string ConnectionString { get; set; }

        /// <summary>
        /// Change connection string of first child of already existing xmlElement connectionStrings
        /// </summary>
        public void SetConnectionString()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement xElement in xmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    xElement.FirstChild.Attributes["connectionString"].Value = this.ConnectionString;
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        private string CreateConnectionString()
        {
            bool isExpress = this.ServerInstances
                .Any(x => x.ToLower().Contains(EXPRESS.ToLower()));

            string dataSource = isExpress ? DATA_SOURCE_EXPRESS : DATA_SOURCE_MSSQL;
            string connectionString =
                string.Format(CONNECTION_STRING_FORMAT, dataSource, this.DatabaseName, this.IntegratedSecurity);

            return connectionString;
        }
    }
}
