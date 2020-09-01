using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfLoggerRepository : EfGenericRepository<Log>, ILoggerDal
    {
    }
}
