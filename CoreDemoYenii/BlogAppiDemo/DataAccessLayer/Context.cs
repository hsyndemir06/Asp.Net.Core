using Microsoft.EntityFrameworkCore;

namespace BlogAppiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        // baglantı stringini tanımlamıs olduk
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-4GGBVQ1\\HSYN;database=BlogApiDb; integrated security=true; TrustServerCertificate=true; ");
        }

        public DbSet<Employee> Employees { get; set; }


    }
}
