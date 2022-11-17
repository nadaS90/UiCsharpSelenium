using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Data
{
    public class FileReaders
    {
        private static log4net.ILog Logger => log4net.LogManager.GetLogger(typeof(FileReaders));
        public FileReaders()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public static string GetJsonFormattedMessage(string FileName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\n");
            sb.Append("\"MessageDT\": \"20211220163850979\",");
            sb.Append("\n");
            sb.Append("\"Text\": ");
            sb.Append(ReadHL7File(FileName));
            sb.Append(",");
            sb.Append("\n");
            sb.Append("\"Id\": ");
            sb.Append("\"932b13fc-e80d-45bf-8c74-94b16c791bf4\",");
            sb.Append("\n");
            sb.Append("\"CustomerId\": ");
            sb.Append($"\"{Common.Common.CustomerId}\",");
            sb.Append("\n");
            sb.Append("\"SolutionId\": ");
            sb.Append($"\"{Common.Common.SolutionId}\"");
            sb.Append("\n");
            sb.Append("}");
            var Message = sb.ToString();
            return Message;
        }
        public static string ReadHL7File(string FileName)
        {
            FindHL7MessageLocation();
            return ReadHL7FileContent(FileName);
        }
        public static string ReadXMLFile(string FileName)
        {
            FindXMLFileLocation();
            return ReadXMLFileContent(FileName);
        }

        private static string ReadHL7FileContent(string FileName)
        {
            Logger.Info("Reading HL7 File from it's location");
            Mapping.HL7MessageContent = File.ReadAllText(string.Format("{0}\\{1}", Mapping.HL7FileLocation, FileName));
            Logger.Info("Returning HL7 Message Content");
            return Mapping.HL7MessageContent;
        }

        private static void FindHL7MessageLocation()
        {
            Logger.Info("Finding HL7 Message Location");
            Mapping.ProjectRootDirectory = String.Concat(Regex.Split((Assembly.GetExecutingAssembly().Location), "MedBankTests")[0], "Data");
            Mapping.HL7FileLocation = string.Format("{0}\\Hl7Messages\\", Mapping.ProjectRootDirectory);
        }

        private static void FindXMLFileLocation()
        {
            Logger.Info("Finding HL7 Message Location");
            Mapping.ProjectRootDirectory = String.Concat(Regex.Split((Assembly.GetExecutingAssembly().Location), "MedBankTests")[0], "Data");
            Mapping.XMLFileLocation = string.Format("{0}\\XMLFiles\\", Mapping.ProjectRootDirectory);
        }
        private static string ReadXMLFileContent(string FileName)
        {
            Logger.Info("Reading HL7 File from it's location");
            Mapping.ExpectedXMLFileContent = File.ReadAllText(string.Format("{0}\\{1}", Mapping.XMLFileLocation, FileName));
            Logger.Info("Returning HL7 Message Content");
            return Mapping.ExpectedXMLFileContent;
        }
    }
}
