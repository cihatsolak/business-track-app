using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;

namespace BusinessTrack.Business.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        void SendNotificationsManagers(AppUser currentUser = null, string message = null, List<AppUser> administrators = null);
        List<Notification> GetMessagesByReadStatus(int userId, bool readStatus = false);
        int GetUnreadNotificationsCountByUserId(int id);
    }
}
