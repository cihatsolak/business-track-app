using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Factories;
using BusinessTrack.Web.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Areas.Member.Controllers
{
    public class AccountController : BaseMemberController
    {
        private readonly IAppUserModelFactory _appUserModelFactory;
        public AccountController(
            UserManager<AppUser> userManager,
            IAppUserModelFactory appUserModelFactory) : base(userManager)
        {
            _appUserModelFactory = appUserModelFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var appUser = await CurrentUser();
            var appUserViewModel = _appUserModelFactory.PrepareAppUserViewModel(appUser);
            return View(appUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(AppUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await CurrentUser();

            if (user == null)
                return RedirectToAction(nameof(Profile));

            user = await _appUserModelFactory.PrepareAdminAppUserEntity(model, user);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(Profile));
        }
    }
}
