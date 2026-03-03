using ClientManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientManagerApi.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
