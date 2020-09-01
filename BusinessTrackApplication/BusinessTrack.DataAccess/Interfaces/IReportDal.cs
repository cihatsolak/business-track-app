using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;

namespace BusinessTrack.DataAccess.Interfaces
{
    public interface IReportDal : IGenericDal<Report>
    {
        List<Report> GetReportsByAssignmentId(int id);
        Report GetReportWithAssignment(int id);
        int GetReportCountByUserId(int id);
        int GetAllReportCount();
    }
}
