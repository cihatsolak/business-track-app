using BusinessTrack.Web.Models;

namespace BusinessTrack.Web.Areas.Admin.Models.Assignments
{
    public class AssignmentListAllViewModel : BaseEntityModel<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedOn { get; set; }
        public string ExigencyDefinition { get; set; }
        public string AppUserFullName { get; set; }
        public int ReportCount { get; set; }
    }
}
