using System.Collections.Generic;


namespace ConfigurationManager.Options
{
    public class DefaultOptions
    {
        public string sourceDirectoryPath = "C:\\YCHEBA\\ИСП\\Lab4\\Test\\SourceDirectory";
        public string targetDirectoryPath = "C:\\YCHEBA\\ИСП\\Lab4\\Test\\TargetDirectory";
        public string targetArchivePath = "C:\\YCHEBA\\ИСП\\Lab4\\Test\\TargetDirectory\\archive";
        public int key = 12;
        public int id = 2;
        public string dataSource = ".\\SQLEXPRESS";
        public string initialCatalog = "AdventureWorks2017";
        public string integratedSecurity = "True";
        public string xmlDirectory = "C:\\YCHEBA\\ИСП\\Lab4\\Test\\XmlFiles";
        public DefaultOptions() { }
    }
}
