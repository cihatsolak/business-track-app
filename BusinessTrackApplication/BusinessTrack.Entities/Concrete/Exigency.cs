using BusinessTrack.Entities.Interfaces;
using System.Collections.Generic;

namespace BusinessTrack.Entities.Concrete
{
    public class Exigency : BaseEntity<int>, IEntity
    {
        #region Properties
        public string Definition { get; set; }
        #endregion

        #region Relationships
        public List<Assignment> Assignments { get; set; }
        #endregion
    }
}
