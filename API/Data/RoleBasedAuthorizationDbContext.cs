
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.Models;

namespace RoleBasedAuthorization.Data
{
    public class RoleBasedAuthorizationDbContext : DbContext
    {
        public RoleBasedAuthorizationDbContext(DbContextOptions<RoleBasedAuthorizationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<ProductDatum> Products { get; set; }
    }
}
