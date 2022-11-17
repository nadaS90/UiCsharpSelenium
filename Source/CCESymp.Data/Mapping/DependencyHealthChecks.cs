using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.Data.Mapping
{
    public class DependencyHealthChecks
    {

        public ServiceInformation SQLServer { get; set; }
        public ServiceInformation Elasticsearch { get; set; }
        public ServiceInformation MessageTracingQueue { get; set; }
        public ServiceInformation MessageTracingIngestFunction { get; set; }

        public ServiceInformation AuditContainer { get; set; }
    }
}
