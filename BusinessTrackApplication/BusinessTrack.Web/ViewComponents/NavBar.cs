using BusinessTrack.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessTrack.Web.ViewComponents
{
    public class NavBar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public NavBar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //Burada kaldım.
            return View();
        }
    }
}
