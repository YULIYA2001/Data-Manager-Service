using ConfigurationManager.XmlJsonParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Options
{
    public static class EtlXmlOptions
    {
        public static DefaultOptions GetXmlOptions(XmlParser xp)
        {
            DefaultOptions defOp = new DefaultOptions();

            defOp.sourceDirectoryPath = xp.TakeVariableValue("sourceDirectoryPath");
            defOp.targetDirectoryPath = xp.TakeVariableValue("targetDirectoryPath");
            defOp.targetArchivePath = xp.TakeVariableValue("targetArchivePath");
            try
            {
                int key = Convert.ToInt32(xp.TakeVariableValue("key"));
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
                int id = Convert.ToInt32(xp.TakeVariableValue("id"));
                if (id > 0 && id < 501)
                {
                    defOp.id = id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            defOp.dataSource = xp.TakeVariableValue("DataSource");
            defOp.initialCatalog = xp.TakeVariableValue("InitialCatalog");
            defOp.integratedSecurity = xp.TakeVariableValue("IntegratedSecurity");
            defOp.xmlDirectory = xp.TakeVariableValue("XmlDirectory");
            return defOp;
        }
    }
}
