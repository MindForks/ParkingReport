using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PR.Entities;

namespace PR.Data
{
    public class PRDbContext : IdentityDbContext<User>
    {
        private string ConnectionString;

        public PRDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #region DbSets
        public DbSet<AttachedFile> AttachedFile { get; set; }
        public DbSet<ReportStatus> ReportStatus { get; set; }
        public DbSet<Report> Report { get; set; }

        #endregion DbSets

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, options => options.EnableRetryOnFailure());
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReportStatus>()
             .HasKey(k => k.Id);
            modelBuilder.Entity<ReportStatus>()
               .Property(p => p.Title).IsRequired();
            modelBuilder.Entity<ReportStatus>()
                .HasData(
                new ReportStatus() { Title = "Created", Id = (int)ReportStatuses.Created },
                new ReportStatus() { Title = "InProgress", Id = (int)ReportStatuses.InProgress },
                new ReportStatus() { Title = "FalseIncident", Id = (int)ReportStatuses.FalseIncident },
                new ReportStatus() { Title = "CarAbsent", Id = (int)ReportStatuses.CarAbsent },
                new ReportStatus() { Title = "Fixed", Id = (int)ReportStatuses.Fixed }
                );

            modelBuilder.Entity<AttachedFile>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<AttachedFile>()
                .Property(t => t.Path).IsRequired();
            modelBuilder.Entity<AttachedFile>()
               .HasOne(o => o.Report)
               .WithMany(m => m.AttachedFiles)
               .HasForeignKey(k => k.ReportId);

            modelBuilder.Entity<Report>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<Report>()
                .HasOne(o => o.User)
                .WithMany(m => m.Reports)
                .HasForeignKey(k => k.UserId);

        }
    }
}