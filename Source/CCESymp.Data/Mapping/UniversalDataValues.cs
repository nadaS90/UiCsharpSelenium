namespace CCESymp.Data.Mapping
{
    public class UniversalDataValues
    {
        public string Url;
        public string Username;

        public UniversalDataValues(string value)
        {
            string[] SplitValues = value.Split(',');
            Username = getBetween(SplitValues[0], "\"username\":\"", "\"");
            Url = getBetween(SplitValues[1], "\"url\":\"", "\"");
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            return "";
        }

    }
}
