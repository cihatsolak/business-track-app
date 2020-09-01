using BusinessTrack.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BusinessTrack.Entities.Concrete
{
    public class AppRole : IdentityRole<int>, IEntity // integer primary key
    {
    }
}
