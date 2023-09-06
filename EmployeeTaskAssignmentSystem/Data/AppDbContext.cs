using EmployeeTaskAssignmentSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskAssignmentSystem.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-JEURKMP\\SQLEXPRESS;Database=ETAS4;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; } 
        public DbSet<TaskModel> Tasks { get; set; } 
    }
}
