using Core.Entities.Models;
using Core.Entities.RequestParametrs;
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

    public async Task<Employee> GetEmployeeAsync(Guid Id)
    {
        var employee = await FindByCondition(e => e.Id == Id).FirstOrDefaultAsync();

        return employee;
    }

    public async Task<IEnumerable<Employee>> GetUnEmployees(DepartmentAssignParams param)
    {
        var employees = await FindAll().Where(e => e.Department.Name == param.department)
            .Where(e => e.Busy == false).ToListAsync();

        return employees;
    }

    public async Task EmployeeAssign(Employee emp)
    {
        var employee = await RepositoryContext.Employees.Where(e => e.Id == emp.Id).FirstOrDefaultAsync();

        employee.Busy = true;
    }
}