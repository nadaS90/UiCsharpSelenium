namespace CCESymp.Data.Mapping
{
    public class AuditLogging
    {
        public int ID { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Permission { get; set; }
        public int Success { get; set; }
        public string Description { get; set; }
    }
}
