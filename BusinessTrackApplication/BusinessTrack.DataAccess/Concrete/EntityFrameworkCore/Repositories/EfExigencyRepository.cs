using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfExigencyRepository : EfGenericRepository<Exigency>, IExigencyDal
    {
    }
}
