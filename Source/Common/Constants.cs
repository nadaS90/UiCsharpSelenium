namespace Common
{
    public class Constants
    {
        private static log4net.ILog Logger => log4net.LogManager.GetLogger(typeof(Common));
        public Constants()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public class Buttons
        {
            public static readonly string UPDATE = "update";
            public static readonly string CANCEL = "cancel";
            public static readonly string EDIT = "edit";
            public static readonly string PUBLISH = "publish";
            public static readonly string VIEW = "view";
            public static readonly string SAVE = "save";
            public static readonly string DELETE = "delete";
            public static readonly string CLOSE = "close";
            public static readonly string YES = "yes";
            public static readonly string NO = "no";
            public static readonly string OK = "ok";
            public static readonly string SEARCH = "search";
        }

        public class RSSConstants {
            public static readonly string RSSKeyName = "X-Atlas-SecurityKey";
            public static readonly string RSSKeyValue = "75162FD1-A4E8-40AB-A62A-823932CEAD1F";
            public static readonly string GetCustomersEndpoint = "api/odata/Customers";
        }

        public static string CloseButtonXpath = "//span[contains(text(),'×')] | (//button[contains(text(),'Close')])[last()]";

        public static string FormatIgnoreCaseXpath(string Text) => $"(//button[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'),'{Text}')])[last()]";

        public static string[] separators = { "MSH", "PID", "DG1", "EVN", "GT1", "IN1", "NK1", "NTE", "OBR", "OBX", "ORC", "FT1", "ZFM", "MFI", "MFE", "TQ1", "PV1", "RXO", "RXR", "RXE", "RXD", "ZRX", "AL1", "ACK", "DFT", "MDM", "MFN", "ORM", "ORU", "QRY", "RAS", "RGV", "SIU", "PD1", "MRG", "ARV" };
    }
}
