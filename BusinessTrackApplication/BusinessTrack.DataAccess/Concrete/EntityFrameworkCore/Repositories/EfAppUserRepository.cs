using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Entities.Concrete.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetAllMember(out int totalCount, int pageIndex, string keyword = null)
        {
            using var context = new BusinessTrackContext();
            var query = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                User = resultUser,
                UserRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.UserRole.RoleId, roles => roles.Id, (resultTable, resultRole) => new
            {
                resultTable.User,
                UserRoles = resultTable.UserRole,
                Roles = resultRole
            }).Where(i => i.Roles.Name.Equals("Member")).Select(i => new AppUser
            {
                Id = i.User.Id,
                Name = i.User.Name,
                Surname = i.User.Surname,
                Picture = i.User.Picture,
                Email = i.User.Email,
                UserName = i.User.UserName
            });

            if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(i => i.Name.ToLower().Contains(keyword.ToLower())
                                    || i.Surname.ToLower().Contains(keyword.ToLower()));
            }

            totalCount = query.Count();

            query = query.Skip((pageIndex - 1) * 3).Take(3);

            return query.ToList();
        }

        public List<DualHelper> GetMostWorkCompletedWithFiveStaff()
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.AppUser)
                                           .Where(i => i.Status)
                                           .GroupBy(i => i.AppUser.UserName)
                                           .OrderByDescending(i => i.Count());

            var query2 = query.Take(5).Select(i => new DualHelper
            {
                Name = i.Key,
                AssignmentCount = i.Count()
            });

            return query2.ToList();
        }

        public List<DualHelper> GetMostEmployedStaff()
        {
            using var context = new BusinessTrackContext();
            var query = context.Assignments.Include(i => i.AppUser)
                                           .Where(i => !i.Status && i.AppUserId != null)
                                           .GroupBy(i => i.AppUser.UserName)
                                           .OrderByDescending(i => i.Count());

            var query2 = query.Take(5).Select(i => new DualHelper
            {
                Name = i.Key,
                AssignmentCount = i.Count()
            });

            return query2.ToList();
        }
    }
}
