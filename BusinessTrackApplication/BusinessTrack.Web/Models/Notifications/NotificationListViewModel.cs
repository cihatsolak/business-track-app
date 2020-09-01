using System.Collections.Generic;

namespace BusinessTrack.Web.Models.Notifications
{
    public class NotificationListViewModel
    {
        public NotificationListViewModel()
        {
            NotificationList = new List<NotificationViewModel>();
        }
        public List<NotificationViewModel> NotificationList { get; set; }
    }
}
