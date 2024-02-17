using Core.Entities.Models;

namespace Core.Interfaces.Repository;

public interface IEmployeesRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(string? department, bool? busy);
}