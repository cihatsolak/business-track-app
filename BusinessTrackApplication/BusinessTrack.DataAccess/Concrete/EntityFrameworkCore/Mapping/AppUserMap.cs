using BusinessTrack.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(i => i.Name).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Surname).HasMaxLength(100).IsRequired();

            /* AppUser ile Assignment arasında bir ilişki kurmak.
             * HasMany : n olan taraf.
             * WithOne : 1 olan taraf.
             * HasForeignKey: İlişki kurulacak id.
             * OnDelete: İlgili user silindiğinde ona bağlı kolonları null olarak ata.
             */
            builder.HasMany(i => i.Assignments).WithOne(i => i.AppUser).HasForeignKey(i => i.AppUserId).OnDelete(DeleteBehavior.SetNull);
        }
    } 
}
