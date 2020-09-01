using BusinessTrack.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessTrack.Web.Areas.Admin.Models.Assignments
{
    public class AssignmentViewModel : BaseEntityModel<int>
    {
        public AssignmentViewModel()
        {
            Exigencies = new List<SelectListItem>();
        }

        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CreatedOn { get; set; }

        [Display(Name = "Aciliyet Durumu Seçiniz")]
        public int ExigencyId { get; set; }
        public string ExigencyDefinition { get; set; }
        public IList<SelectListItem> Exigencies { get; set; }
    }
}
