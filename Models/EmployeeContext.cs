using Microsoft.EntityFrameworkCore;

namespace CRUD_Opertions.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options):base(options) 
        {
            
        }
    public DbSet<Employee> Employees { get; set; }
    }
}
