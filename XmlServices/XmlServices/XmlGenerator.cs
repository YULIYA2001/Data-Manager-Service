using System;
using System.IO;
using System.Xml.Linq;
using ServiceLayer.DTO;

namespace XmlServices
{
    public class XmlGenerator
    {
        public string generatedPath;
        public XmlGenerator(PersonDTO person, string xmlDirectory)
        {
            XDocument xdoc = new XDocument(new XElement("Person",
                new XElement("Personality",
                    new XElement("ID", person.Id),
                    new XElement("First_name", person.FirstName),
                    new XElement("Last_name", person.LastName)),
                new XElement("Contacts",
                    new XElement("Phone_number", person.PhoneNumber),
                    new XElement("Type_of_phone_number", person.PhoneNumberType),
                    new XElement("Email", person.Email)),
                new XElement("Full_address",
                    new XElement("Address", person.Address),
                    new XElement("City", person.City),
                    new XElement("Province", person.Province),
                    new XElement("Country", person.Country))));

            if (!Directory.Exists(xmlDirectory))
            {
                Directory.CreateDirectory(xmlDirectory);
            }
            generatedPath = xmlDirectory + "\\Person" + person.Id
                + DateTime.Now.ToString("-yyyy_MM_dd_HH_mm_ss") + ".xml";
            xdoc.Save(generatedPath);
        }
    }
}
