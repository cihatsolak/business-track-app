using BusinessTrack.Web.Models;
using BusinessTrack.Web.Models.Users;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Models.Assignments
{
    public class AssignmentAppUserViewModel : BaseEntityModel<int>
    {
        public AssignmentAppUserViewModel()
        {
            AppUsers = new List<AppUserViewModel>();
        }

        public string Name { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public string CreatedOn { get; set; }
        public List<AppUserViewModel> AppUsers { get; set; }

        public int ActivePage { get; set; }
        public int TotalPage { get; set; }
        public string SearchKeyword { get; set; }
    }
}
