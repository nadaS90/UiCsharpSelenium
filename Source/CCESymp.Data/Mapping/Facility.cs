using System.ComponentModel.DataAnnotations;
using CCESymp.Data.Mapping;

namespace CCESymp.Data.Mapping
{
    public sealed class Facility : Entity
    {
        public int CustomerId { get; set; }
        public string FacilityId { get; set; }
        public string RSSId { get; set; }
        public string IntegrationId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address
        {
            get
            {
                string address = string.Empty;
                if (!string.IsNullOrEmpty(Address1))
                {
                    address = $"{Address1}";
                }

                if (!string.IsNullOrEmpty(Address2))
                {
                    address = !string.IsNullOrEmpty(address) ? $"{address}, {Address2}" : Address2;
                }

                return address;
            }
        }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string ContactName { get; set; }
    }
}