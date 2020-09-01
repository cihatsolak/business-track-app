using BusinessTrack.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ExigencyMap : IEntityTypeConfiguration<Exigency>
    {
        public void Configure(EntityTypeBuilder<Exigency> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();

            builder.Property(i => i.Definition).HasMaxLength(100).IsRequired();
        }
    }
}
