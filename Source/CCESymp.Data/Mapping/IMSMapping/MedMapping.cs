namespace CCESymp.Data.Mapping.IMSMapping
{
        public class MedMapping
        {

            public static string HL7MessageContent { get; set; }
            public static string ProjectRootDirectory { get; set; }
            public static string HL7FileLocation { get; set; }
            public static string HL7MessageDecode { get; set; }

            public static string XMLFileLocation { get; set; }
            public static string ExpectedXMLFileContent { get; set; }
            public static string MedBankGeneratedXML { get; set; }
            public static string MedBankServerResponse { get; set; }
            public static string ResponseCode200 = "<Status code=\"200\" text=\"OK\" />";
            public static string HL7ParsingError = "[HL7 Parsing error - inboundhl7] ca.uhn.hl7v2.HL7Exception: The HL7 version 2.6.1 is not recognized";
            public static string UnknownHL7Exception = "[HL7->XML mapping error] com.bd.cce.medbank.exception.UnknownHL7Exception: ADT A102 HL7 2.5.1 not supported.";
            public static string DropMessage = "Drop Message: Message Type/Version Not Supported.";
            public static string ImportFailedMessage = "MedBank response status code 500. Import failed on ProfileID: - Missing server information for customer DB ccetesting_sdiego. Message stay in queue.";
            public static string URLErrorMessage = "[URL error] org.apache.camel.FailedToCreateProducerException: Failed to create Producer for endpoint: cxf://bean:medbankPatientWebService?address=https%3A%2F%2Fstmql.medbank.com%2Fwebservices3%2FAutocribWSPost.asmx&defaultOperationName=ProcessPatientProfile&defaultOperationNamespace=http%3A%2F%2Fwww.mycubex.net%2F&headerFilterStrategy=%23myCxfFilter&wsdlURL=https%3A%2F%2Fstmql.medbank.com%2Fwebservices3%2FAutocribWSPost.asmx%3Fwsdl. Reason: org.apache.cxf.service.factory.ServiceConstructionException: Failed to create service.";
            public static string SolutionError = "[HL7->XML mapping error] com.bd.cce.medbank.exception.SolutionConfigNotFoundException: com.bd.cce.medbank.exception.SolutionConfigNotFoundException: class com.bd.cce.medbank.model.hl7.template.HL7Templates$RDEMappingTemplate not found in solution config. not found in solution config.";
            public static string MappingError = @"[HL7->XML mapping error] com.bd.cce.medbank.exception.MappingTemplateParsingException: Invalid Mapping Template. Unable to parse. java.lang.IllegalArgumentException: The pattern PID 3 is not valid. Only [\w\*\?]* allowed.";
            public static string CurrentUniversalTime { get; set; }

        }
}
