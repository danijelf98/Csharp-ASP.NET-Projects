using Microsoft.EntityFrameworkCore;
using Vjezba11042024.Models.Dbo;

namespace Vjezba11042024.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vozilo> Vehicles { get; set; }
    }
}
