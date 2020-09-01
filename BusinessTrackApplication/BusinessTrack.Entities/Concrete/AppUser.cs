using BusinessTrack.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BusinessTrack.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity //integer primary key
    {
        #region Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
        #endregion

        #region Relationships
        public List<Assignment> Assignments { get; set; }
        public List<Notification> Notifications { get; set; }
        #endregion
    }
}
