using BusinessTrack.Web.Models;

namespace BusinessTrack.Web.Areas.Admin.Models.Assignments
{
    public class AssignUserViewModel : BaseEntityModel<int>
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserPicture { get; set; }
        public string UserEmail { get; set; }
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public string AssignmentExigencyDefinition { get; set; }
    }
}
