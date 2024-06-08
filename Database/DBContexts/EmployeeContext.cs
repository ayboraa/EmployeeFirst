using Microsoft.EntityFrameworkCore;
using EmployeeFirst.Models;

namespace EmployeeFirst.Database.DBContexts
{

    public class EmployeeContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString:
               "Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=demo;SearchPath=scheme;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
