using BusinessTrack.Entities.Interfaces;

namespace BusinessTrack.Entities.Concrete
{
    public class Report : BaseEntity<int>, IEntity
    {
        #region Properties
        public string Definition { get; set; }
        public string Detail { get; set; }
        #endregion

        #region RelationShips
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        #endregion
    }
}
