using System.IO;
using System;
using ConfigurationManager.Options;
using ConfigurationManager.XmlJsonParser;

namespace ConfigurationManager
{
    public class Manager
    {     
        public DefaultOptions GetOptions()
        {
            DefaultOptions defOp = new DefaultOptions();
            AppDomain domain = AppDomain.CurrentDomain;

            string xmlPath = domain.BaseDirectory + "config.xml";
            string jsonPath = domain.BaseDirectory + "appsettings.json";
            //string xmlPath = "C:\\YCHEBA\\ИСП\\Lab4\\config.xml";
            //string jsonPath = "C:\\YCHEBA\\ИСП\\Lab4\\appsettings.json";

            int stop = 0;            

            if (File.Exists(xmlPath))
            {
                XmlParser x = new XmlParser(xmlPath);
                if (x.nodes is null)
                {
                    stop = 1;
                }
                else
                {                 
                    defOp = EtlXmlOptions.GetXmlOptions(x);
                }
            }
            else
            {
                stop = 1;
            }
            if (File.Exists(jsonPath) && stop == 1)
            {
                JsonParser j = new JsonParser(jsonPath);
                if (!(j.nodes is null))
                {
                    defOp = EtlJsonOptions.GetJsonOptions(j);       
                }
            }
            return defOp;
        }
    }
}

