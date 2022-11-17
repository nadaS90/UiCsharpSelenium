using System.Collections.Generic;
    public class RoleDetails
    {
        public List<DetailsData> data { get; set; }
        public int code { get; set; }
        public string status { get; set; }
        public string message { get; set; }

    public class DetailsData
    {
        public string id { get; set; }
        public string clientId { get; set; }
        public string version { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public string category { get; set; }
        public bool systemLevel { get; set; }
    }
}

