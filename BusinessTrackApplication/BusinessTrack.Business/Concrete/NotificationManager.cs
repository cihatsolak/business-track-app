using BusinessTrack.Business.Interfaces;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessTrack.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public void Insert(Notification entity)
        {
            _notificationDal.Insert(entity);
        }

        public void Insert(IEnumerable<Notification> entities)
        {
            _notificationDal.Insert(entities);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }

        public void Delete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public void Delete(IEnumerable<Notification> entities)
        {
            _notificationDal.Delete(entities);
        }

        public void SendNotificationsManagers(AppUser currentUser = null, string message = null, List<AppUser> administrators = null)
        {
            if (currentUser == null)
                throw new ArgumentNullException(nameof(currentUser));

            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            if (administrators == null)
                throw new ArgumentNullException(nameof(message));

            foreach (var admin in administrators)
            {
                _notificationDal.Insert(new Notification
                {
                    Message = $"{currentUser.Name} {currentUser.Surname} {message}",
                    AppUserId = admin.Id,
                });
            }            
        }

        public List<Notification> GetMessagesByReadStatus(int userId = 0, bool readStatus = false)
        {
            if (userId == 0)
                throw new ArgumentNullException(nameof(userId));

            return _notificationDal.GetMessagesByReadStatus(userId, readStatus);
        }

        public int GetUnreadNotificationsCountByUserId(int id)
        {
            return _notificationDal.GetUnreadNotificationsCountByUserId(id);
        }
    }
}
