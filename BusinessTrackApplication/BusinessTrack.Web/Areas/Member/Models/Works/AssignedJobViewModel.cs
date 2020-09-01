using BusinessTrack.Web.Areas.Member.Models.Reports;
using BusinessTrack.Web.Models;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Member.Models.Works
{
    public class AssignedJobViewModel : BaseEntityModel<int>
    {
        public AssignedJobViewModel()
        {
            Reports = new List<ReportViewModel>();
        }

        public string Name { get; set; }
        public string ExigencyDefinition { get; set; }
        public string Description { get; set; }
        public int ReportCount { get; set; }
        public List<ReportViewModel> Reports { get; set; }
    }
}
