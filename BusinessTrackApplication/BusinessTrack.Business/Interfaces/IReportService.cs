using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;

namespace BusinessTrack.Business.Interfaces
{
    public interface IReportService : IGenericService<Report>
    {
        List<Report> GetReportsByAssignmentId(int id);
        Report GetReportWithAssignment(int id);
        int GetReportCountByUserId(int id);
        int GetAllReportCount();
    }
}
