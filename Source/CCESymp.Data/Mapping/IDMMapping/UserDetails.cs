using System;

namespace CCESymp.Data.IDMMapping
{
    public class UserDetails
    {
        public Data data { get; set; }
        public int code { get; set; }
        public string status { get; set; }
        public string message { get; set; }

        public class Data
        {
            public string parentKey { get; set; }
            public string tenantKey { get; set; }
            public string subject { get; set; }
            public bool isAccountClosedFlag { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string suffix { get; set; }
            public string initials { get; set; }
            public string middleInitial { get; set; }
            public string userScanCode { get; set; }
            public string userBadgeId { get; set; }
            public string jobTitle { get; set; }
            public bool exemptFromBioId { get; set; }
            public DateTime accountExpirationDateTime { get; set; }
            public bool isLoginAllowedFlag { get; set; }
            public string email { get; set; }
            public bool isAccountVerifiedFlag { get; set; }
            public bool isPinConfiguredFlag { get; set; }
            public bool canExpireFlag { get; set; }
            public DateTime lastModifiedDateTime { get; set; }
            public DateTime accountCreationDateTime { get; set; }
            public string userKey { get; set; }
            public string preferredLanguage { get; set; }
            public bool directoryAccount { get; set; }
        }
    }   
}
