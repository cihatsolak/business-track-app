using BusinessTrack.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AssignmentMap : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();

            builder.Property(i => i.Name).HasMaxLength(50).IsRequired();
            builder.Property(i => i.Description).HasColumnType("ntext");

            builder.HasOne(i => i.Exigency).WithMany(i => i.Assignments).HasForeignKey(i => i.ExigencyId);
        }
    }
}
