using BusinessTrack.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessTrack.Web.Areas.Admin.Models.Exigencies
{
    public class ExigencyViewModel : BaseEntityModel<int>
    {
        [Display(Name = "Tanım")]
        public string Definition { get; set; }
    }
}
