using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CCESymp.Data.Mapping
{
    public sealed class Customer : Entity
    {
        public Customer()
        {
            Facilities = new HashSet<Facility>();
        }

        public string Name { get; set; }
        public string RSSId { get; set; }
        public string IntegrationId { get; set; }
        public Guid GlobalId { get; set; }
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
        public string Notes { get; set; }
        public int TotalCount { get; set; }
        public ICollection<Facility> Facilities { get; set; }
    }
}