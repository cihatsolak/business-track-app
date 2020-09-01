using BusinessTrack.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.Definition).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Detail).HasColumnType("ntext").HasMaxLength(250).IsRequired();

            //Bir görev silindiğinde buna ait raporlarda EF tarafından otomatik olarak silinecektir.
            builder.HasOne(i => i.Assignment).WithMany(i => i.Reports).HasForeignKey(i => i.AssignmentId);
        }
    }
}
