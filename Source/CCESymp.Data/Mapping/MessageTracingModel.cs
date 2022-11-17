namespace CCESymp.Data.Mapping
{
    public class MessageTracingModel : Entity
    {
        public string SolutionId { get; set; }
        public string DateTime { get; set; }
        public string Component { get; set; }
        public string Source { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }
    }
}