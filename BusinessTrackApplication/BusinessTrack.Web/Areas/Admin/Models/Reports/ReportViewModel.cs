using BusinessTrack.Web.Models;

namespace BusinessTrack.Web.Areas.Admin.Models.Reports
{
    public class ReportViewModel : BaseEntityModel<int>
    {
        public string Definition { get; set; }
        public string Detail { get; set; }
    }
}
