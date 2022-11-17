using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.Data.Mapping
{
    public class PublishModel : Entity
    {

        public string CustomerID { get; set; }
        public string Name { get; set; }//Using name for the endpoint
        public string Notes { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string TemplateTypeId { get; set; }
        public string SolutionName { get; set; }

        public int SolutionId { get; set; }
        public string CustomerName { get; set; }
        public string TemplateTypeName { get; set; }
        public string BusinessUnitName { get; set; }
        public bool IsBusinessUnitPermitted { get; set; }
        public string BusinessUnit { get; set; }
        public string ConfigurationValue { get; set; }
        public string Configurations { get; set; }
        public string Customer { get; set; }

        public Guid CustomerGlobalId { get; set; }

        public string FacilityCode { get; set; }

        public string FacilityPassword { get; set; }

        public string FacilityUsername { get; set; }

        public Guid GlobalId { get; set; }

        public bool IsPublished { get; set; }

        public string TemplateType { get; set; }
        public string TemplateVersion { get; set; }

        public Configuration configuration { get; set; }

        public PublishModel()
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
