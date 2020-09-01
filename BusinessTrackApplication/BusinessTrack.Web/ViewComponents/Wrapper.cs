using BusinessTrack.Business.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessTrack.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserModelFactory _appUserModelFactory;
        private readonly INotificationService _notificationService;
        public Wrapper(
            UserManager<AppUser> userManager,
            IAppUserModelFactory appUserModelFactory,
            INotificationService notificationService)
        {
            _userManager = userManager;
            _appUserModelFactory = appUserModelFactory;
            _notificationService = notificationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var appUserWrapperModel = _appUserModelFactory.PrepareAppUserWrapperModel(user);

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
                appUserWrapperModel.IsAdmin = true;

            appUserWrapperModel.UnreadMessageCount = _notificationService.GetMessagesByReadStatus(user.Id, false).Count;

            return View(appUserWrapperModel);
        }
    }
}
