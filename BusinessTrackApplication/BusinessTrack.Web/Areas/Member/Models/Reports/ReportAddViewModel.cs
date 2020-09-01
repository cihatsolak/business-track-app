using BusinessTrack.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessTrack.Web.Areas.Member.Models.Reports
{
    public class ReportAddViewModel : BaseEntityModel<int>
    {
        [Display(Name = "Tanım")]
        public string Definition { get; set; }
        [Display(Name = "Detay")]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public string AssignmentExigencyDefinition { get; set; }
    }
}
