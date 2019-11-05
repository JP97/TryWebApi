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
    }
}