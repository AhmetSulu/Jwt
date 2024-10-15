using Jwt.Models;
using Microsoft.EntityFrameworkCore;

namespace Jwt.Data
{
    public class JwtDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public JwtDbContext(DbContextOptions<JwtDbContext> options) : base(options)
        {
        }
    }
}
