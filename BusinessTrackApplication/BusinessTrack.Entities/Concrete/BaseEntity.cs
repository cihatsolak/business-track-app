using BusinessTrack.Entities.Interfaces;

namespace BusinessTrack.Entities.Concrete
{
    public abstract class BaseEntity<TVariable> : IEntity
    {
        public TVariable Id { get; set; }
    }
}
