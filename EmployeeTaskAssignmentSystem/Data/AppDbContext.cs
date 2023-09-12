using EmployeeTaskAssignmentSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskAssignmentSystem.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-JEURKMP\\SQLEXPRESS;Database=ETAS2;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
