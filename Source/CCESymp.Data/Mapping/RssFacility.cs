using System;

namespace CCESymp.Data.Mapping
{
    public class RssFacility
    {
        public string FacilityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ServiceLevel { get; set; }
        public bool IsDeleted { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string ZipCode { get; set; }
        public string IntegrationType { get; set; }
        public string IntegrationId { get; set; }
        public bool IsAccessApprovalRequired { get; set; }
    }
}
