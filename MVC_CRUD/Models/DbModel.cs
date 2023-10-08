using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models
{
    public enum Grade
    {
        M01, M02, M03, M04, M05,
        Ex01, G01, D01
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EnumDataType(typeof(Grade))]
        public Grade Grade { get; set;}
        public string Department { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}