using System;

namespace ConfigurationManager.Options
{
    public class dbOptions
    {
        public string connectionString;
        public string xmlDirectory;
        public string sourceDirectoryPath;
        public int id;

        public dbOptions()
        {
            DefaultOptions defOp = new DefaultOptions();
            defOp = new Manager().GetOptions();
            connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security={2}",
                defOp.dataSource, defOp.initialCatalog, defOp.integratedSecurity);
            xmlDirectory = defOp.xmlDirectory;
            sourceDirectoryPath = defOp.sourceDirectoryPath;
            id = defOp.id;
        }
    }
}
