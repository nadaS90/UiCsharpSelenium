using System;

namespace CCESymp.Data.Mapping
{
    public class EndpointSolutionModel : Entity
    {
        public int customerId { get; set; }
        public string name { get; set; }
        public Guid globalId { get; set; }
        public string description { get; set; }
        public string Category { get; set; }
    }
}
