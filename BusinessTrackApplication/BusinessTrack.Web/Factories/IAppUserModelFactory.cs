using BusinessTrack.Entities.Concrete;
using BusinessTrack.Entities.Concrete.Helpers;
using BusinessTrack.Web.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Factories
{
    public partial interface IAppUserModelFactory
    {
        AppUserViewModel PrepareAppUserViewModel(AppUser appUser = null);
        Task<AppUser> PrepareAdminAppUserEntity(AppUserViewModel appUserViewModel = null, AppUser appUser = null);
        AppUser PrepareWebAppUserEntity(AppUserViewModel appUserViewModel = null);
        AppUserWrapperModel PrepareAppUserWrapperModel(AppUser appUser = null);
        string PrepareDualHelperListJsonModel(List<DualHelper> dualHelpers = null);
    }
}
