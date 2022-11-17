using System.Collections.Generic;

namespace CCESymp.Data.Mapping
{
    public class AdminGlobalConnectionType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }

        public List<GlobalConnectionModel> uiInputs { get; set; }
    }
}