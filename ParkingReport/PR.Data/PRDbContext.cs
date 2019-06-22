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

        #endregion DbSets

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, options => options.EnableRetryOnFailure());
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}