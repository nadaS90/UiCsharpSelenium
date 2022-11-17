using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Sockets;

namespace Common
{
    public partial class MBCommon
    {
        private const int IP4Family = 4;
        private const int IP6Family = 6;

        public static string StorageConnectionString = GetEnvVar(@"StorageConnectionString", @"DefaultEndpointsProtocol=https;AccountName=ccesandboxuswmedbankstg;AccountKey=WFXmGBrIZWATPrmzvBh5eGFPr3q2/rvbqcIxLdyOdwe6URIFAJaodRytZmAm692AAUrPkfvYWoRZSHCe47962A==;EndpointSuffix=core.windows.net");
        public static string CustomerId = GetEnvVar(@"CustomerId", @"6ac6e364-a89e-4484-9143-874c4933396f");
        public static string SolutionId = GetEnvVar(@"SolutionId", @"f63e80eb-a605-4113-8d0e-597deb57bad0");
        public static string sFQDN = System.Net.Dns.GetHostEntry("").HostName;
        private static log4net.ILog Logger => log4net.LogManager.GetLogger(typeof(Common));

        public MBCommon()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        //Stage URL: https://hsce-dashboard-stg.bdx-cloud.com/
        //Stage Username: ccead2@mailinator.com
        //Stage Password: Password1234!
        //Stage Customer Name: BD Internal
        //Stage Solution Name: CCEMBTest - EC

        //TST URL: https://hsce-dashboard-tst.bdx-cloud.com/
        //TST Username: admin1@cce.com
        //TST Password: password
        //TST Customer Name: BD Internal
        //TST Solution Name: MBIMS-EC
        public static string TakeMBMValues = GetEnvVar(@"TakeMBMValues", "true");

        //public static string RelayReceiverEndpointURL = GetEnvVar(@"RelayReceiverEndpointURL", https://hsce-relayreceiver-stg.bdx-cloud.com/);
        //public static string FacilityCode = GetEnvVar(@"FacilityCode", "IMSAutomation");
        ////user and password came from the HttpsMBM.cfg file
        //public static string APIUser = GetEnvVar(@"APIUser", "}=yX$(;QtV9{d1(3g;8h{k8qS4yUcD?8f8(4vPncX-vq]nC9NQ_IkpD_}yFtqsG-*j$MMfo20bpPwp>g.uX9>!XHAm0BF2+0$tmj2jYGBPtk2i[/$d&v5m5hh2fqHQ=O");
        //public static string EncodedAPIPassword = GetEnvVar(@"EncodedAPIPassword", "._ /@?YPyb;||KUy}k)sNzg-;j.vN0D#.&_C/.roH>u-Q!#L$o!G[ZC>SC%{i;t}c}{c?R!rI[#WU_>e!!_.Gw-Sz;J%RNwg-*yo$8G-7O(|{k%{bCL))]|%]]Q_Oe=FQ");

        public static string RelayReceiverEndpointURL = GetEnvVar(@"RelayReceiverEndpointURL", "https://hsce-relayreceiver-tst.bdx-cloud.com/");
        public static string FacilityCode = GetEnvVar(@"FacilityCode", "CCESQETest_SM1");
        //user and password came from the HttpsMBM.cfg file
        public static string APIUser = GetEnvVar(@"APIUser", "#gdD2CJFhynpI^Y4b!Hp(_f$-0AYu+I83S@I3&amp;gl7!grZ*5kg|I!8V)2t2)FOb=K!oDwv-f*_7z5SyikZO0uhvaKPT$Wh^Is)Tr-43Eo[fb3n}{!=M5Q%^N%ZzIeq[Yp");
        public static string EncodedAPIPassword = GetEnvVar(@"EncodedAPIPassword", "$Y&amp;*&gt;}G&amp;])[).).+a3Fd&amp;=L77I;#zE7D^b1s+u3-Uu-!}|K_&amp;[.oB}]}z(4y_);pfI1!&gt;83-LRn^=)*+)gm&gt;f}[.g?9F?kQSN[_R}OnL+]6Sium6=.(!S-;m3U9yqK=)");

        /*Temp Environments*/
        public static string LocalIP6 = GetLocalIP(IP6Family);
        //Host Details
        public static string HostIpAddress = GetEnvVar(@"HostIpAddress", @"127.0.0.1");
        public static string ServerPort = GetEnvVar(@"ServerPort", @"14005");
        //Test Usernames
        public static string CCESympCustomerAdmin = GetEnvVar(@"CCESympCustomerAdmin", "@admin1@cce.com");
        public static string CCESymp_Login_PW = GetEnvVar(@"CCESymp_Login_PW", @"password");
        //UI URL
        public static string CCESymp_DashboardUI_Url = GetEnvVar(@"CCESymp_DashboardUI_Url", @"https://hsce-dashboard-tst.bdx-cloud.com/");
        //MedBank DB Details
        public static string MedBankIMS_DefaultPatientURL = GetEnvVar(@"MedBankIMS_DefaultPatientURL", @"https://med.myqlink.net/webservices3/AutocribWSPost.asmx");
        public static string MedBankIMS_DefaultBillingURL = GetEnvVar(@"MedBankIMS_DefaultBillingURL", @"https://med.myqlink.net/webservices3/AutocribWS.asmx");
        public static string MedBankIMS_DeactivatePatientURL = GetEnvVar(@"MedBankIMS_DeactivatePatientURL", @"https://med.myqlink.net/webservices3a/CubexWebServices3aPost.asmx");
        public static string MedBankIMS_DatabasePassword = GetEnvVar(@"MedBankIMS_DatabasePassword", @"cGWj04Ma");
        public static string MedBankIMS_CustomerName = GetEnvVar(@"MedBankIMS_CustomerName", @"BD Internal");
        public static string MedBankIMS_SolutionName = GetEnvVar(@"MedBankIMS_SolutionName", @"CCESQETest_SM1");
        //Browser selection
        public static string browsersToRunWith = GetEnvVar(@"browsersToRunWith", @"Chrome");

        public static string SendToHostAction = "Send to Host";
        public static string DropMessageAction = "Drop Message";
        public static string MappingErrorAction = "mapping error";
        public static string GetZMAAction = "GetStockDestockTransactionsResponse";
        public static string GetZPMAction = "GetZPMTransactionsResponse";
        public static string GetBillingAction = "GetBillingResponse";
        public static string HL7ParsingErrorAction = "HL7 Parsing error";
        public static string SendToHostFailedAction = "Send to Host: Failed to send to MedBank Server.";
        public static string NonProcessableRequestAction = "Server was unable to process request";
        public static string ParsingException = "[HL7->XML mapping error] com.bd.cce.medbank.exception.MappingTemplateParsingException";
        public static string ResponseSentToHost = "Response from Sent to Host";

        public static string GetEnvVar(string EnvName = "", string DefaultValue = "")
        {
            /* RR: Replacing this with registry lookup since new variables set are not seen in current session
             * string LookupValue = Environment.GetEnvironmentVariable(EnvName);
             * if(!string.IsNullOrEmpty(LookupValue))
             * {
             *      rValue = LookupValue;
             * } */
            string SysEnv_RegRoot = @"hkey_local_machine\SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
            string rValue = GetRegVal(SysEnv_RegRoot, EnvName, DefaultValue);
            return rValue;
        }

        private static string GetRegVal(string KeyName = "", string ValueName = "", string DefaultValue = "")
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }

            // Seems C# does root path/hive differently. For now, assuming all checks are for localmachine
            // written specifically for SQE testing so current user and others should not be referenced
            string rValue;
            try
            {
                rValue = Registry.GetValue(KeyName, ValueName, DefaultValue).ToString();
            }
            catch
            {
                // get value only uses default value if keyname is valid.
                // This will catch the error if path does not exist and use default value
                rValue = DefaultValue;

                // Output that regpath invalid for SQE for testing. Reason is default value may be good but still need to know if regpath invalid
                Logger.Info(string.Format("Reg path did not exist so default value used.\r\n  Regpath: '{0}'\r\n  ValueName: {1}\r\n  DefaultValue: {2}", KeyName, ValueName, DefaultValue));
            }
            return rValue;
        }

        private static string GetLocalIP(int IPVersion = 4)
        {
            // Default ipfamily and response if empty
            AddressFamily IPFamily = System.Net.Sockets.AddressFamily.InterNetwork;
            string LocalIPString = @"IP4 Address not found";
            if (IPVersion == 6)
            {
                IPFamily = System.Net.Sockets.AddressFamily.InterNetworkV6;
                LocalIPString = @"IP6 Address not found";
            }

            IPAddress[] LocalIPList = System.Net.Dns.GetHostEntry(sFQDN).AddressList;
            IPAddress LocalIP = Array.Find(LocalIPList, lIP => lIP.AddressFamily == IPFamily);
            if (LocalIP != null)
            {
                LocalIPString = LocalIP.ToString();
            }
            return LocalIPString;
        }
    }
}

