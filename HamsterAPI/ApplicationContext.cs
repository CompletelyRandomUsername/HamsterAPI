using Microsoft.EntityFrameworkCore;

namespace HamsterAPI.Controllers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Hamster> hamsters { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HamsterDatabase;Username=postgres;Password=Jckbr6Ceckbr6");
        }
    }
}
