using BusinessTrack.Business.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Areas.Member.Controllers
{
    public class NotificationController : BaseMemberController
    {
        private readonly INotificationService _notificationService;
        private readonly INotificationModelFactory _notificationModelFactory;
        public NotificationController(
            INotificationService notificationService,
            UserManager<AppUser> userManager,
            INotificationModelFactory notificationModelFactory) : base(userManager)
        {
            _notificationService = notificationService;
            _notificationModelFactory = notificationModelFactory;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var user = await CurrentUser();
            var notifications = _notificationService.GetMessagesByReadStatus(user.Id);
            var notificationListViewModel = _notificationModelFactory.PrepareNotificationListViewModel(notifications);
            return View(notificationListViewModel);
        }

        [HttpPost]
        public IActionResult Read(int id)
        {
            if (id < 1)
                return RedirectToAction(nameof(List));

            var notification = _notificationService.GetById(id);

            if (notification == null)
                return RedirectToAction(nameof(List));

            notification.Status = true;
            _notificationService.Update(notification);

            return RedirectToAction(nameof(List));
        }
    }
}
