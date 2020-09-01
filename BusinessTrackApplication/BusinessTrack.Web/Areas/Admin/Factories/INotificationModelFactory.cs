using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Models.Notifications;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Factories
{
    public interface INotificationModelFactory
    {
        NotificationListViewModel PrepareNotificationListViewModel(List<Notification> notifications = null);
    }
}
