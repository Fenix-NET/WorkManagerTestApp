using ConsoleDataGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleDataGenerator.Data;

public class WorkDBContext : DbContext
{
    public string connectionString { get; set; }

    public WorkDBContext(string connectionString)
    {
        this.connectionString = connectionString;
        Database.EnsureCreated();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql(connectionString);
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    
}