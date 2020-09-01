using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetMessagesByReadStatus(int userId, bool readStatus)
        {
            using var context = new BusinessTrackContext();
            var query = context.Notifications.Where(i => i.AppUserId == userId && i.Status == readStatus);
            return query.ToList();
        }

        public int GetUnreadNotificationsCountByUserId(int id)
        {
            using var context = new BusinessTrackContext();
            return context.Notifications.Count(i => i.AppUserId == id && !i.Status);
        }
    }
}
