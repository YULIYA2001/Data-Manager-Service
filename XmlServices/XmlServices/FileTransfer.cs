using ConfigurationManager.Options;
using ServiceLayer.DTO;
using ServiceLayer.Services;
using System;
using System.IO;

namespace XmlServices
{
    public class FileTransfer
    {
        public void Move(dbOptions dbOp)
        {
            PersonDTO person = new PersonService().GetPerson(dbOp.connectionString, dbOp.id);
            XmlGenerator xmlG;
            try
            {
                xmlG = new XmlGenerator(person, dbOp.xmlDirectory);
                string newPath = dbOp.sourceDirectoryPath;
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                newPath = xmlG.generatedPath.Replace(dbOp.xmlDirectory, newPath);                
                File.Copy(xmlG.generatedPath, newPath);
            }
            catch { }
        }
    }
}
