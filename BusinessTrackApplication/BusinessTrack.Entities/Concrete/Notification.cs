using BusinessTrack.Entities.Interfaces;

namespace BusinessTrack.Entities.Concrete
{
    public class Notification : BaseEntity<int>, IEntity
    {
        #region Properties
        public string Message { get; set; }
        public bool Status { get; set; }
        #endregion

        #region RelationShips
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        #endregion
    }
}
