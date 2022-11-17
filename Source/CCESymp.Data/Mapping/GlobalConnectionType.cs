using System;

namespace CCESymp.Data.Mapping
{
    public class GlobalConnectionType
    {
        public int customerId { get; set; }
        public int globalConnectionTypeId { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validTo { get; set; }
        public string customer { get; set; }
        public int id { get; set; }
        public string globalConnectionType { get; set; }

        public string Type { get; set; }
        public string Version { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }

        public GlobalConnectionType()
        {
            if (this.Description is null)
            {
                this.Description = "";
            }
        }

    }
}
