using Core.Entities.Dtos;
using Core.Entities.Models;
using Core.Entities.RequestParametrs;

namespace Core.Interfaces;

public interface IEmployeesService
{
    public Task<IEnumerable<EmloyeeDto>> GetEmployeesAsync(string? department, bool? busy);
    public Task<Employee> GetBusyEmployeeAsync(Guid Id);
    public Task<Employee> GetUnEmployees(DepartmentAssignParams param);
    public Task AssignTask(Employee employee);
}