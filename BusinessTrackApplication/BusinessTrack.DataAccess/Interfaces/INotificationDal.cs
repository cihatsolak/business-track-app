using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;

namespace BusinessTrack.DataAccess.Interfaces
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        List<Notification> GetMessagesByReadStatus(int userId, bool readStatus);
        int GetUnreadNotificationsCountByUserId(int id);
    }
}
