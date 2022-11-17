using System.Collections.Generic;

namespace CCESymp.Data.Mapping
{
    public class LoginAttemptHistoryResponse
    {
        public string Username { get; set; }
        public string UserAccountKey { get; set; }
        public List<LoginAttempHistoryData> LoginHistory { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseStatus { get; set; }
    }
    public class LoginAttempHistoryData
    {
        public string Status { get; set; }
        public string LoginAttemptDateTime { get; set; }
        public string IpAddress { get; set; }
    }
}
