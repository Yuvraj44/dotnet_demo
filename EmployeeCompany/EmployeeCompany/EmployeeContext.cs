using EmployeeCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeCompany
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> EmployeeList { get; set; }
        public DbSet<Department> DepartmentList { get; set; }
    }
}
