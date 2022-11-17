namespace CCESymp.Data.Mapping
{
    public class FacilityModel
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string FacilityId { get; set; }
        public string RSSID { get; set; }
        public string IntegrationId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public CustomerModel Customer { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string ContactName { get; set; }

        public FacilityModel()
        {
            if (this.Id is null)
            {
                this.Id = "";
            }

            if (this.CustomerId is null)
            {
                this.CustomerId = "";
            }

            if (this.FacilityId is null)
            {
                this.FacilityId = "";
            }

            if (this.RSSID is null)
            {
                this.RSSID = "";
            }

            if (this.IntegrationId is null)
            {
                this.IntegrationId = "";
            }

            if (this.Name is null)
            {
                this.Name = "";
            }

            if (this.Address1 is null)
            {
                this.Address1 = "";
            }

            if (this.Address2 is null)
            {
                this.Address2 = "";
            }
            if (this.Address is null)
            {
                this.Address = "";
            }

            if (this.City is null)
            {
                this.City = "";
            }

            if (this.CityCode is null)
            {
                this.CityCode = "";
            }

            if (this.State is null)
            {
                this.State = "";
            }

            if (this.StateCode is null)
            {
                this.StateCode = "";
            }

            if (this.ZipCode is null)
            {
                this.ZipCode = "";
            }

            if (this.Phone is null)
            {
                this.Phone = "";
            }

            if (this.Email is null)
            {
                this.Email = "";
            }

            if (this.CountryCode is null)
            {
                this.CountryCode = "";
            }

            if (this.CountryName is null)
            {
                this.CountryName = "";
            }

            if (this.ContactName is null)
            {
                this.ContactName = "";
            }
        }
    }
}