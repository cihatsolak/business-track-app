using AutoMapper;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Models.Notifications;
using System;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Factories
{
    public class NotificationModelFactory : INotificationModelFactory
    {
        private readonly IMapper _mapper;
        public NotificationModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public NotificationListViewModel PrepareNotificationListViewModel(List<Notification> notifications = null)
        {
            if (notifications == null)
                throw new ArgumentNullException(nameof(notifications));

            var notificationListViewModel = new NotificationListViewModel();

            foreach (var notification in notifications)
            {
                var notificationViewModel = _mapper.Map<NotificationViewModel>(notification);
                notificationListViewModel.NotificationList.Add(notificationViewModel);
            }

            return notificationListViewModel;
        }
    }
}
