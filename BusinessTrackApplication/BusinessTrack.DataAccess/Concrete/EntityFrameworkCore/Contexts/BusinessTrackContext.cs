using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using BusinessTrack.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class BusinessTrackContext : IdentityDbContext<AppUser, AppRole, int> //AppUser,AppRole ile çalış, primary key'in int.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HPPROBOOK;Database=BusinessTrackDb;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AssignmentMap());
            modelBuilder.ApplyConfiguration(new ExigencyMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new LogMap());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Exigency> Exigencies { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
