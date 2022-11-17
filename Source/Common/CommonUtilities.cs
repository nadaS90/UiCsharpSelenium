using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace Common
{
    public class CommonUtilities
    {
        private static log4net.ILog Logger => log4net.LogManager.GetLogger(typeof(Common));
        public CommonUtilities()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static bool ValidateIPAddress(string Ip)
        {
            bool validation = IPAddress.TryParse(Ip, out _);
            return validation;
        }
        public static bool ValidateDate(string date)
        {
            bool validation = DateTime.TryParse(date, out _);
            return validation;
        }
        public static int GenerateRandomNumber(int start, int end)
        {
            Random random = new Random();
            int randnum = random.Next(start, end);
            return randnum;
        }
        public static float GenerateRandomDecimalNumber(int start, int end)
        {
            Random rnd = new Random();
            float result = rnd.Next(start, end) * 0.111f + start;
            return result;
        }
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public static string RandomStringWithSpecialChar(int length)
        {
            Random ran = new Random();
            string b = "abcdefghijklmnopqrstuvwxyz0123456789";
            string sc = "!@#$%^&*~";
            //int length = 6;
            string finalString = string.Empty;

            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(b.Length); //string.Lenght gets the size of string
                finalString += b.ElementAt(a);
            }
            for (int j = 0; j < 2; j++)
            {
                int sz = ran.Next(sc.Length);
                finalString += sc.ElementAt(sz);
            }
            return finalString;
        }
        public static string GenerateRandomPassword()
        {
            StringBuilder str = new StringBuilder();
            str.Append(RandomStringWithSpecialChar(6));
            str.Append(GenerateRandomNumber(10, 99));
            str.Append(RandomString(1, false));
            var password = str.ToString();
            return password;
        }
       

        //public static string GetInstalledEdgeVersion()
        //{
        //    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Edge\\BLBeacon");
        //    RegistryKey SecondKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate\Clients\{56EB18F8-B008-4CBD-B6D2-8C97FE7E9062}");

        //    var CurrentUserEdgeVersion = key.GetValue("version");
        //    var LocalMachineEdgeVersion = SecondKey.GetValue("pv");
        //    if (string.IsNullOrEmpty(CurrentUserEdgeVersion.ToString()))
        //    {
        //        return LocalMachineEdgeVersion.ToString();
        //    }
        //    else
        //    {
        //        return CurrentUserEdgeVersion.ToString();
        //    }
        //}

        //public static string GetInstalledEdgeDriverVersion()
        //{
        //    string EdgeDriverVersion;
        //    try
        //    {
        //        var EdgeDriverInfo = FileVersionInfo.GetVersionInfo(String.Concat(GetCoreDriverPath(), "msedgedriver.exe"));
        //        EdgeDriverVersion = EdgeDriverInfo.ProductVersion;
        //    }
        //    catch
        //    {
        //        EdgeDriverVersion = "";
        //    }

        //    return EdgeDriverVersion;
        //}

        public static void KillActiveChromeTasks()
        {
            Logger.Info("Attempting to kill any active Chrome Tasks/Processes...");

            Process[] KillChromeProcess = Process.GetProcessesByName("chromedriver");
            Process[] KillChromeBrowser = Process.GetProcessesByName("chrome");

            if (KillChromeProcess.Length > 0 || KillChromeBrowser.Length > 0)
            {
                Logger.Info("Killing Active Chrome Tasks");

                try
                {
                    foreach (var process in KillChromeProcess)
                    {
                        process.Kill();
                    }
                   
                    foreach (var process in KillChromeBrowser)
                    {
                        process.Kill();
                    }
                }
                catch
                {
                    Logger.Info("Chrome Processes Could Not Be Killed");
                }

            }
            else
            {
                Logger.Info("Chrome Processes Did Not Exist");
            }
            
        }

        public static void KillActiveEdgeTasks()
        {
            Logger.Info("Attempting to kill any active Edge Tasks/Processes...");

            Process[] KillEdgeProcess = Process.GetProcessesByName("MicrosoftWebDriver");
            Process[] KillEdgeBrowser = Process.GetProcessesByName("msedge");
            Process[] msedgeProcess = Process.GetProcessesByName("msedgedriver");

            if (KillEdgeBrowser.Length > 0 || KillEdgeProcess.Length > 0 || msedgeProcess.Length > 0)
            {
                Logger.Info("Killing Active Edge Tasks");
                try
                {

                    foreach (var process in KillEdgeProcess)
                    {
                        process.Kill();
                    }

                    foreach (var process in KillEdgeBrowser)
                    {
                        process.Kill();
                    }

                    foreach (var process in msedgeProcess)
                    {
                        process.Kill();
                    }
                }
                catch
                {
                    Logger.Info("Edge Processes Could Not Be Killed");
                }
            }
            else
            {
                Logger.Info("Edge Processes Did Not Exist");
            }            
        }

        public static string GenerateRandomString(int stringLenght)
        {
            Random ran = new Random();
            String b = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            String random = "";

            for (int i = 0; i < stringLenght; i++)
            {
                int a = ran.Next(52);
                random += b.ElementAt(a);
            }

            return random;
        }

        public static string GenerateRandomAlphanumericString(int stringLenght)
        {
            Random ran = new Random();
            String b = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            String random = "";

            for (int i = 0; i < stringLenght; i++)
            {
                int a = ran.Next(62);
                random += b.ElementAt(a);
            }

            return random;
        }


        public static string GetMonthName(string month, string year)
        {
            DateTime date = new DateTime(Int32.Parse(year), Int32.Parse(month), 1);
            return date.ToString("MMMM");

        }

    }
}
