using System;
using ConfigurationManager.XmlJsonParser;

namespace ConfigurationManager.Options
{
    public static class EtlJsonOptions
    {
        public static DefaultOptions GetJsonOptions(JsonParser jp)
        {
            DefaultOptions defOp = new DefaultOptions();

            defOp.sourceDirectoryPath = jp.TakeVariableValue("sourceDirectoryPath");
            defOp.targetDirectoryPath = jp.TakeVariableValue("targetDirectoryPath");
            defOp.targetArchivePath = jp.TakeVariableValue("targetArchivePath");
            try
            {
                int key = Convert.ToInt32(jp.TakeVariableValue("key"));
                if (key > 0 && key < 146)
                {
                    defOp.key = key;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                int id = Convert.ToInt32(jp.TakeVariableValue("id"));
                if (id > 0 && id < 501)
                {
                    defOp.id = id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            defOp.dataSource = jp.TakeVariableValue("DataSource");
            defOp.initialCatalog = jp.TakeVariableValue("InitialCatalog");
            defOp.integratedSecurity = jp.TakeVariableValue("IntegratedSecurity");
            defOp.xmlDirectory = jp.TakeVariableValue("XmlDirectory");
            return defOp;
        }
    }
}
