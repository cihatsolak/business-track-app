using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public int GetAllReportCount()
        {
            using var context = new BusinessTrackContext();
            return context.Reports.Count();
        }

        public int GetReportCountByUserId(int id)
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.Reports).Where(i => i.AppUserId == id);
            return query.SelectMany(i => i.Reports).Count();
        }

        public List<Report> GetReportsByAssignmentId(int id)
        {
            using var context = new BusinessTrackContext();
            return context.Reports.Where(i => i.AssignmentId == id).ToList();
        }

        public Report GetReportWithAssignment(int id)
        {
            using var context = new BusinessTrackContext();
            return context.Reports.Include(i => i.Assignment).ThenInclude(i => i.Exigency).SingleOrDefault(i => i.Id == id);
        }
    }
}
