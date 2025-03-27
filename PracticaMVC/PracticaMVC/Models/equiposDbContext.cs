using Microsoft.EntityFrameworkCore;
namespace PracticaMVC.Models
{
    public class equiposDbContext: DbContext
    { 
        public equiposDbContext(DbContextOptions<equiposDbContext> options) : base(options) 
        {
        }

        public DbSet<marcas> Marcas { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<equipos> equipos { get; set; }
    }
}
