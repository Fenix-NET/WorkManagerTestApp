using Core.Entities.Models;
using Core.Entities.RequestParametrs;

namespace Core.Interfaces.Repository;

public interface IEmployeesRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(string? department, bool? busy);
    Task<Employee> GetEmployeeAsync(Guid Id);
    public Task<IEnumerable<Employee>> GetUnEmployees(DepartmentAssignParams param);

    public Task EmployeeAssign(Employee emp);
}