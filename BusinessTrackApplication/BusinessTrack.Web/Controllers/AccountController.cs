using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Constants;
using BusinessTrack.Web.Factories;
using BusinessTrack.Web.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserModelFactory _appUserModelFactory;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(
            UserManager<AppUser> userManager, 
            IAppUserModelFactory appUserModelFactory, 
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserModelFactory = appUserModelFactory;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı ya da şifreniz hatalıdır.");
                return View(model);
            }

            /*
             * isPersistent : Beni hatırla. Cookie
             * lockOutOnFailure: belirlenen miktarda yanlış giriş sonucu hesabı kilitleme.
             */
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı ya da şifreniz hatalıdır.");
                return View(model);
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains(RoleInfo.Admin))
                return RedirectToAction("Index", "Home", new { area = RoleInfo.Admin });

            if (roles.Contains(RoleInfo.Member))
                return RedirectToAction("Index", "Home", new { area = RoleInfo.Member });

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _appUserModelFactory.PrepareWebAppUserEntity(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View(model);
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!addRoleResult.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View(model);
            }

            return RedirectToAction(nameof(SignIn));
        }

        
    }
}
