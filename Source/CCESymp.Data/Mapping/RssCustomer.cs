using System;

namespace CCESymp.Data.Mapping
{
    public class RssCustomer : CustomerModel
    {
        public string CustomerId { get; set; }
        public string Description { get; set; }
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
        public string CountryCode { get; set; }
        public string IntegrationType { get; set; }
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
