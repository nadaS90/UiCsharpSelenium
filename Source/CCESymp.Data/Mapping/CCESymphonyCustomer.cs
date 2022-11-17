using System.Collections.Generic;

namespace CCESymp.Data.Mapping
{
    public class CCESymphonyCustomer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RSSID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Notes { get; set; }

        public List<CCESymphonyCustomer> customersList { get; set; }
    }
}
