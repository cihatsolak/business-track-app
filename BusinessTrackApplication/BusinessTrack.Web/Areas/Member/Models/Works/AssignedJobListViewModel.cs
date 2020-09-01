using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Member.Models.Works
{
    public class AssignedJobListViewModel
    {
        public AssignedJobListViewModel()
        {
            AssignedJobs = new List<AssignedJobViewModel>();
        }
        public List<AssignedJobViewModel> AssignedJobs { get; set; }
    }
}
