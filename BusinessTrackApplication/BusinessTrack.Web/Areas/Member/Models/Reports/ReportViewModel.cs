using BusinessTrack.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessTrack.Web.Areas.Member.Models.Reports
{
    public class ReportViewModel : BaseEntityModel<int>
    {
        [Display(Name = "Tanım")]
        public string Definition { get; set; }
        [Display(Name = "Detay")]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }
    }
}
