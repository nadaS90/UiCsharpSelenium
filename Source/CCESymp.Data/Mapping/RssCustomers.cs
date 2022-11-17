using System;

namespace CCESymp.Data.Mapping
{
    public class RssCustomers
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
        public string CityCode { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string ZipCode { get; set; }
        public string IntegrationType { get; set; }
        public string IntegrationId { get; set; }
        public string CustomerType { get; set; }
        public string GAG { get; set; }
        public bool IDN { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
