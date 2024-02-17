using Core.Entities.Models;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeesRepository : RepositoryBase<Employee>, IEmployeesRepository
{
    public EmployeesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(string? department, bool? busy)
    {
        IQueryable<Employee> employees = FindAll().Include(e => e.Department);
            
        
        if (!String.IsNullOrEmpty(department))
        {
            employees = employees.Where(e => e.Department.Name == department);
        }

        if (busy.HasValue)
        {
            employees = employees.Where(e => e.Busy == busy);
        }


        return await employees.ToListAsync();
    }
}