using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAssignmentRepository : EfGenericRepository<Assignment>, IAssignmentDal
    {
        public List<Assignment> GetAllInCompleteWithRelationships(out int totalPageCount, int userId, int pageIndex)
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.Exigency)
                                            .Include(i => i.Reports)
                                            .Include(i => i.AppUser)
                                            .Where(i => i.AppUserId == userId && i.Status)
                                            .OrderByDescending(i => i.CreatedOn);

            totalPageCount = query.Count();

            return query.Skip((pageIndex - 1) * 3).Take(3).ToList();
        }

        public List<Assignment> GetAllWithAssociatedTables()
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.Exigency)
                                           .Include(i => i.Reports)
                                           .Include(i => i.AppUser);

            return query.Where(i => !i.Status).OrderByDescending(i => i.CreatedOn).ToList();
        }

        public List<Assignment> GetAllWithAssociatedTablesByUserId(int userId)
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.Exigency)
                                           .Include(i => i.Reports)
                                           .Include(i => i.AppUser)
                                           .Where(i => !i.Status && i.AppUserId == userId);

            return query.OrderByDescending(i => i.CreatedOn).ToList();
        }

        public List<Assignment> GetAssignmentsByUserId(int userId)
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Where(i => i.AppUserId == userId);
            return query.ToList();
        }

        public Assignment GetAssignmentWithExigencyById(int id)
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.Exigency).Where(i => !i.Status);

            return query.FirstOrDefault(i => i.Id == id);
        }

        public Assignment GetAssignmentWithReports(int id)
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.Reports).Include(i => i.AppUser);
            return query.FirstOrDefault(i => i.Id == id);
        }

        public int GetCompletedTaskCount()
        {
            using var context = new BusinessTrackContext();
            return context.Assignments.Count(i => i.Status);
        }

        public int GetCompletedTaskCountByUserId(int id)
        {
            using var context = new BusinessTrackContext();
            return context.Assignments.Count(i => i.AppUserId == id && i.Status);
        }

        public List<Assignment> GetIncompleteAssignmentWithExigency()
        {
            //Eager Loading : Görevler class'ını çağırırken beraberinde aciliyeti de getirdim.
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.Exigency).Where(i => !i.Status);
            return query.OrderByDescending(x => x.CreatedOn).ToList();
        }

        public int GetInCompletedTaskCountByUserId(int id)
        {
            using var context = new BusinessTrackContext();
            return context.Assignments.Count(i => i.AppUserId == id && !i.Status);
        }

        public int GetUnAssignedTaskCount()
        {
            using var context = new BusinessTrackContext();
            return context.Assignments.Count(i => i.AppUserId == null && !i.Status);
        }
    }
}
