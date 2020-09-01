using BusinessTrack.Entities.Concrete;
using BusinessTrack.Entities.Concrete.Helpers;
using System.Collections.Generic;

namespace BusinessTrack.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetAllMember(out int totalCount, int pageIndex = 1, string keyword = null);
        List<DualHelper> GetMostWorkCompletedWithFiveStaff();
        List<DualHelper> GetMostEmployedStaff();
    }
}
