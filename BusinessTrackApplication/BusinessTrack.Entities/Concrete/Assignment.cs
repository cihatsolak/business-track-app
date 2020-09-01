using BusinessTrack.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessTrack.Entities.Concrete
{
    public class Assignment : BaseEntity<int>, IEntity
    {
        #region Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion

        #region Relationships
        public int? AppUserId { get; set; } // Görev oluşturulurken illa bir kullanıcı atanması gerekmesin.(nullable.)
        public AppUser AppUser { get; set; }

        public int ExigencyId { get; set; }
        public Exigency Exigency { get; set; }

        public List<Report> Reports { get; set; }
        #endregion
    }
}
