using System.Collections.Generic;
using System.Xml;

namespace ConfigurationManager.XmlJsonParser
{
    public class XmlParser
    {
        // словарь хранит пары имя - значение
        public Dictionary<string, string> nodes;

        public XmlParser(string xmlPath)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(xmlPath);
                nodes = new Dictionary<string, string>();

                foreach (XmlNode node in xDoc.DocumentElement)
                {
                    nodes.Add(node.Name, node.InnerText);
                }
            }
            catch
            {
            }
        }

        public string TakeVariableValue(string name)
        {
            string variableValue = nodes[name];
            return variableValue;
        }
    }
}
