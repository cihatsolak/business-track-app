using BusinessTrack.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.Message).HasColumnType("ntext").IsRequired();

            builder.HasOne(i => i.AppUser).WithMany(i => i.Notifications).HasForeignKey(i => i.AppUserId);
        }
    }
} 
