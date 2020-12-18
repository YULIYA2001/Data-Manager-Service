using System.Collections.Generic;


namespace ConfigurationManager
{
    public class DefaultOptions
    {
        public string sourceDirectoryPath = "C:\\YCHEBA\\ИСП\\Lab4\\SourceDirectory";
        public string targetDirectoryPath = "C:\\YCHEBA\\ИСП\\Lab4\\TargetDirectory";
        public string targetArchivePath = "C:\\YCHEBA\\ИСП\\Lab4\\TargetDirectory\\archive";
        public int key = 12;

        ///////////////////

        public string dataSource = ".\\SQLEXPRESS";
        public string initialCatalog = "AdventureWorks2017";
        public string integratedSecurity = "True";
        public string xmlDirectory = "C:\\YCHEBA\\ИСП\\Lab4\\XmlFiles";
        public DefaultOptions() { }
    }
}
