using System;

namespace CCESymp.Data.Mapping
{
    public class SolutionModel : Entity
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }//Using name for the endpoint
        public Guid globalId { get; set; }
        public Guid CustomerGlobalId { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string TemplateTypeId { get; set; }
        public string SolutionName { get; set; }
        public string CustomerName { get; set; }
        public string TemplateTypeName { get; set; }
        public string BusinessUnitName { get; set; }
        public bool IsBusinessUnitPermitted { get; set; }
        public string Version { get; set; }
        public string FacilityCode { get; set; }
        public string FacilityUsername { get; set; }
        public string FacilityPassword { get; set; }

        public string Template { get; set; }
        public SolutionModel()
        {
            if (Description is null)
            {
                Description = "";
            }
            if (string.IsNullOrEmpty(Notes)) { Notes = ""; }
            if (string.IsNullOrEmpty(Category)) { Category = ""; }
        }

    }
}
