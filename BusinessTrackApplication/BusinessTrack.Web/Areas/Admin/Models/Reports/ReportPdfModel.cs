using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessTrack.Web.Areas.Admin.Models.Reports
{
    public class ReportPdfModel
    {
        [Display(Name = "Tanım")]
        public string Definition { get; set; }
        [Display(Name = "Detay")]
        public string Detail { get; set; }
    }
}
