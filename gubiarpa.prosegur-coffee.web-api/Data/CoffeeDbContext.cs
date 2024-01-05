using gubiarpa.prosegur_coffee.web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gubiarpa.prosegur_coffee.web_api.Data
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
