using BusinessTrack.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();

            builder.Property(i => i.Message).HasColumnType("varchar(MAX)");
            builder.Property(i => i.StackTrase).HasColumnType("varchar(MAX)");
            builder.Property(i => i.Source).HasColumnType("varchar(MAX)");
            builder.Property(i => i.CreatedOn).IsRequired();
        }
    }
}
