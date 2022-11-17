using CCESymp.Data;
using CCESymp.Data.Mapping;
using CCESymp.Data.Mapping.IMSMapping;
using Data;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace CCESymp.UI.Utilities
{
    public class HL7Sender : BaseTest
    {
        public static string FileName { get; set; }
        private static byte[] CombineBytes(byte[] a1, byte[] a2, byte[] a3)
        {
            byte[] values = new byte[a1.Length + a2.Length + a3.Length];
            Array.Copy(a1, 0, values, 0, a1.Length);
            Array.Copy(a2, 0, values, a1.Length, a2.Length);
            Array.Copy(a3, 0, values, a1.Length + a2.Length, a3.Length);
            return values;
        }

        public static void SendHL7Message(string HostName, string Port, string FileName)
        {
            TcpClient TCPConnector = new TcpClient();
            string Message = FileReaders.ReadHL7File(FileName);
            int port = Int32.Parse(Port);

            TCPConnector.Connect(HostName, port);
            SetCurrentUTC();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] b1 = { 0x0B };
            byte[] b2 = { 0x1C, 0x0D };

            //add header an tail to message string
            byte[] BytesArray = CombineBytes(b1, encoding.GetBytes(Message), b2);
            Stream stream = TCPConnector.GetStream();
            stream.Write(BytesArray, 0, BytesArray.Length);

            byte[] bb = new byte[600];
            int k = stream.Read(bb, 0, 600);

            string s = Encoding.UTF8.GetString(bb, 0, k - 1);

            MedMapping.HL7MessageDecode = s;

            TCPConnector.Close();
        }

        public static IRestResponse GetResponse(string endpointUrl, Method requestMethod, Object model = null, bool auth = true, bool file = false)
        {
            RestClient client = new RestClient(MbmMapping.RREndpointURL);
            RestRequest request = new RestRequest(endpointUrl, requestMethod);
            string password = MbmMapping.APIPassword;

            if (auth)
            {
                client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(MbmMapping.APIUsername, password);
            }

            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            if (requestMethod == Method.POST || requestMethod == Method.DELETE || requestMethod == Method.PUT)
            {
                request.AddJsonBody(model);
            }
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static void SendHL7Message(string NameOfFile)
        {
            ReadRelayDetails();

            string CurrentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; //Save current directroy path.
            string FilePath = Path.GetFullPath(string.Concat(CurrentDirectoryPath, $"/Hl7Messages/{NameOfFile}"));
            string FileContent = File.ReadAllText(FilePath);

            HL7Mapping request = new HL7Mapping()
            {
                id = Common.CommonUtilities.GenerateRandomNumber(0, 10000),
                facilitycode = MbmMapping.FacilityCode,
                whenReceived = DateTime.Now.ToString("yyyyMMddHHmmss"),
                text = FileContent,
            };


            List<HL7Mapping> messagesGenerated = new List<HL7Mapping>();
            messagesGenerated.Add(request);

            string body = JsonConvert.SerializeObject(messagesGenerated);

            SetCurrentUTC();

            IRestResponse response = GetResponse($"{MbmMapping.FacilityCode}/api/Message", Method.POST, body);

            var ResponseCode = response.StatusCode.ToString();
            NUnit.Framework.Assert.IsTrue(ResponseCode.Equals("OK"));
        }

        private static void ReadRelayDetails()
        {
            if (Common.MBCommon.TakeMBMValues.Equals("true"))
            {
                string CurrentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; //Save current directroy path.
                string FilePath = Path.GetFullPath(string.Concat(CurrentDirectoryPath, $"/MBMFile/"));
                var Files = Directory.GetFiles(FilePath);
                string FileContent = File.ReadAllText(Path.GetFullPath(Files[1]));

                XmlDocument ResponseXML = new XmlDocument();
                ResponseXML.LoadXml(FileContent);

                var UsernameNode = ResponseXML.SelectSingleNode("//Command[contains(@DefaultInfo, 'The User Name')]");
                MbmMapping.APIUsername = UsernameNode.Attributes["Value"].Value;
                var PasswordNode = ResponseXML.SelectSingleNode("//Command[contains(@DefaultInfo, 'The Password')]");
                MbmMapping.APIPassword = PasswordNode.Attributes["Value"].Value;
                var IdentifierNode = ResponseXML.SelectSingleNode("//Command[contains(@DefaultInfo, 'Identifier')]");
                MbmMapping.FacilityCode = IdentifierNode.Attributes["Value"].Value;
                var RREndpointURLNode = ResponseXML.SelectSingleNode("//Command[contains(@DefaultInfo, 'Service URI used for api access')]");
                MbmMapping.RREndpointURL = RREndpointURLNode.Attributes["Value"].Value;
            }
            else
            {
                MbmMapping.APIUsername = Common.MBCommon.APIUser;
                MbmMapping.APIPassword = Common.MBCommon.EncodedAPIPassword;
                MbmMapping.RREndpointURL = Common.MBCommon.RelayReceiverEndpointURL;
                MbmMapping.FacilityCode = Common.MBCommon.FacilityCode;
            }
        }
    }
}

