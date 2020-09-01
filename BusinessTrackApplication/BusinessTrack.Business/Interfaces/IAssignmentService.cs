using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;

namespace BusinessTrack.Business.Interfaces
{
    public interface IAssignmentService : IGenericService<Assignment>
    {
        List<Assignment> GetIncompleteAssignmentWithExigency();
        List<Assignment> GetAllWithAssociatedTables();
        List<Assignment> GetAllWithAssociatedTablesByUserId(int userId);
        Assignment GetAssignmentWithExigencyById(int id);
        List<Assignment> GetAssignmentsByUserId(int userId);
        Assignment GetAssignmentWithReports(int id);
        List<Assignment> GetAllInCompleteWithRelationships(out int totalPageCount, int userId, int pageIndex);
        int GetCompletedTaskCountByUserId(int id);
        int GetInCompletedTaskCountByUserId(int id);
        int GetUnAssignedTaskCount();
        int GetCompletedTaskCount();
    }
}
