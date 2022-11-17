namespace CCESymp.Data.Mapping
{
    public class CustomerModel : Entity
    {
        public string Name { get; set; }
        public string Rssid { get; set; }
        public string IntegrationId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string Notes { get; set; }
    }
}
