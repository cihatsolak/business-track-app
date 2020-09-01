using BusinessTrack.Web.Areas.Admin.Models.Reports;
using BusinessTrack.Web.Models;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Models.Assignments
{
    public class AssignmentReportsViewModel : BaseEntityModel<int>
    {
        public AssignmentReportsViewModel()
        {
            ReportsViewModel = new List<ReportViewModel>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserFullName { get; set; }
        public List<ReportViewModel> ReportsViewModel { get; set; }
    }
}
