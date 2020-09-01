using BusinessTrack.Entities.Concrete;
using BusinessTrack.Entities.Concrete.Helpers;
using System.Collections.Generic;

namespace BusinessTrack.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetAllMember(out int totalCount, int pageIndex, string keyword = null);
        List<DualHelper> GetMostWorkCompletedWithFiveStaff();
        List<DualHelper> GetMostEmployedStaff();
    }
}
