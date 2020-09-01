using BusinessTrack.Business.Interfaces;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Entities.Concrete.Helpers;
using System.Collections.Generic;

namespace BusinessTrack.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public List<AppUser> GetAllMember(out int totalCount, int pageIndex = 1, string keyword = null)
        {
            return _appUserDal.GetAllMember(out totalCount, pageIndex, keyword);
        }

        public List<DualHelper> GetMostEmployedStaff()
        {
            return _appUserDal.GetMostEmployedStaff();
        }

        public List<DualHelper> GetMostWorkCompletedWithFiveStaff()
        {
            return _appUserDal.GetMostWorkCompletedWithFiveStaff();
        }
    }
}
