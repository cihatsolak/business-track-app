using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    [AutoValidateAntiforgeryToken]
    public class BaseMemberController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;

        public BaseMemberController()
        {

        }
        public BaseMemberController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<AppUser> CurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return user;
        }

        protected void AddError(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}
