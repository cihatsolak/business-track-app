using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Models.Assignments
{
    public class AssignmentListViewModel
    {
        public List<AssignmentViewModel> AssignmemtsViewModel { get; set; }

        public AssignmentListViewModel()
        {
            AssignmemtsViewModel = new List<AssignmentViewModel>();
        }
    }
}
