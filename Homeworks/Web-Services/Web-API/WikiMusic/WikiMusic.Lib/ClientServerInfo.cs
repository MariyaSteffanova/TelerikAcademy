namespace WikiMusic.Lib
{
    using Microsoft.Win32;

    public class ClientServerInfo
    {
        public ClientServerInfo()
        {
            this.Servers = this.GetClientServerInstances();
        }

        public string[] Servers { get; set; }

        private string[] GetClientServerInstances()
        {
            RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");

            var sqlInstances = key.GetValueNames();

            key.Close();
            baseKey.Close();

            return sqlInstances;
        }
    }
}
