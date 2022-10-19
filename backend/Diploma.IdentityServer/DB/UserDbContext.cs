using Microsoft.EntityFrameworkCore;
using Diploma.IdentityServer.Models;

namespace Diploma.IdentityServer.DB
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
    }
}
