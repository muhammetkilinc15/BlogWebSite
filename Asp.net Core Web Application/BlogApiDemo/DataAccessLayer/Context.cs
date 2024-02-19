using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-4GP61KD\\MSSQLSERVER2022;database=Asp150APİ; integrated security=true;TrustServerCertificate=True");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
