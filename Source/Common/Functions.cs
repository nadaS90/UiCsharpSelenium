using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Sockets;

namespace Common
{
    public partial class Common
    {
        private const int IP4Family = 4;
        private const int IP6Family = 6;

        public static string sFQDN = System.Net.Dns.GetHostEntry("").HostName;
        private static log4net.ILog Logger => log4net.LogManager.GetLogger(typeof(Common));



        //Login Elements 
        public static string EmailInputXpath = "//input[@id='email']";
        public static string NextButtonXpath = "//button[@type='submit']";
        public static string PasswordInputXpath = "//input[@id='Password']";
        public static string SignInButtonXpath = "//button[@value='login']";
        public static string NavigationBarXpath = "//div[@id='subnavItems']";
        public static string LoginHistoryOkButtonXpath = "//p-button";
        public static string CloseLoginHistoryButton = "//button[contains(@class, 'close')]";

        // Constants
        public static string CustomerName => GetEnvVar(@"CustomerName", @"BD Internal");
        public static string SolutionName => GetEnvVar(@"SolutionName", @"MBIM-ECTST");
        public static string SolutionTemplateType => GetEnvVar(@"SolutionTemplateType", @"MedBank");
        public static string MappingTemplate => GetEnvVar(@"MappingTemplate", @"\XMLUtilities\MappingTemplate.txt");
        public static string NoPasswordFile => GetEnvVar(@"NoPasswordFile", @"\XMLUtilities\FileWithNoPassword.cfg");
        public static string NoUsernameFile => GetEnvVar(@"NoUsernameFile", @"\XMLUtilities\FileWithNoUsername.cfg");
        public static string NoFacilityCodeFile => GetEnvVar(@"NoFacilityCodeFile", @"\XMLUtilities\FileWithNoFacilityCode.cfg");
        public static string SampleXMLFile => GetEnvVar(@"SampleXMLFile", @"\XMLUtilities\SampleXMLFile.cfg");
        public static string InvalidFormatFile => GetEnvVar(@"InvalidFormatFile", @"\XMLUtilities\FileWithInvalidFormat.cfg");
        public static string HSCEOperationalGuide => GetEnvVar(@"HSCEOperationalGuide", @"\HSCE Operational Guide");
        public static string CustomerWithoutSolutions => GetEnvVar(@"CustomerWithoutSolutions", @"BA Load Test Customer 110");
        public static string Solution_Customer => GetEnvVar(@"Solution_Customer", @"EVAN credential manager");
        public static string Solution_Customer_DBId => GetEnvVar(@"Solution_Customer_DBId", @"12");
        public static string CustomerWithoutFacilities => GetEnvVar(@"CustomerWithoutFacilities", @"Auburn University Veterinary College");
        public static string CurrentUsername = GetEnvVar(@"CurrentUsername", @"");


        public Common()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
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
