using BusinessTrack.Entities.Interfaces;
using System;

namespace BusinessTrack.Entities.Concrete
{
    public class Log : BaseEntity<int>, IEntity
    {
        public string Path { get; set; }
        public string Message { get; set; }
        public string StackTrase { get; set; }
        public string Source { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
