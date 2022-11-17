namespace CCESymp.Data.IDMMapping
{
    public class UserInfo
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string suffix { get; set; }
        public string initials { get; set; }
        public string middleInitial { get; set; }
        public bool isLoginAllowedFlag { get; set; }
        public string expirationDate { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public bool isAccountClosed { get; set; }
        public bool exemptBioId { get; set; }
        public string userBadgeId { get; set; }
        public string userScanCode { get; set; }
        public string rowaId { get; set; }
        public string jobTitle { get; set; }
    }
}
