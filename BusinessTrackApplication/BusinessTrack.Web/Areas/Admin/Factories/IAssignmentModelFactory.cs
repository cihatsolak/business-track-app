using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Models.Assignments;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Factories
{
    public interface IAssignmentModelFactory
    {
        AssignmentListViewModel PrepareAssignmentListViewModel(List<Assignment> assignments = null);
        AssignmentViewModel PrepareAssignmentViewModel(List<Exigency> exigencies = null, Assignment assignment = null);
        AssignmentAppUserViewModel PrepareAssignmentAppUserViewModel(Assignment assignment = null, List<AppUser> users = null, int pageIndex = 1, int totalCount = 1);
        Assignment PrepareAssignmentEntity(AssignmentViewModel assignmentViewModel = null);
        List<AssignmentListAllViewModel> PrepareAssignmentListAllViewModel(List<Assignment> assignments = null);
        AssignUserViewModel PrepareAssignUserViewModel(AppUser user = null, Assignment assignment = null);
        AssignmentReportsViewModel PrepareAssignmentReportsViewModel(Assignment assignment = null);
    }
}
