namespace BusinessTrack.Web.Models
{
    public abstract class BaseEntityModel<TVariable>
    {
        public TVariable Id { get; set; }
    }
}
