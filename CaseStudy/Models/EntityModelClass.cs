using Microsoft.EntityFrameworkCore;

namespace WebApplicationCaseStudy.Models
{
    
        public class User
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserPassword { get; set; }
            public string UserEmail { get; set; }
        }

        public class Employee
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string EmployeeJob { get; set; }
            public string EmployeeSalary { get; set; }
            public string Department { get; set; }
        }

        public class DetailsDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Employee> Employees { get; set; }

            public DetailsDbContext(DbContextOptions<DetailsDbContext> options)
             : base(options)
            {

            }
        }
    }

