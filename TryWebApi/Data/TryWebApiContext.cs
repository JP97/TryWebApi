using Microsoft.EntityFrameworkCore;
using TryWebApi.Models;

namespace TryWebApi.Data
{
    public class TryWebApiContext : DbContext
    {
        public TryWebApiContext(DbContextOptions<TryWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> GetServices { get; set; }
        public DbSet<ServiceAssignment> ServiceAssignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<ServiceAssignment>().ToTable("ServiceAssignment");

            modelBuilder.Entity<ServiceAssignment>().HasKey(s => new { s.UserID, s.ServiceID });
        }
    }
}