using Core.Entities;

namespace Core.Interfaces.Repository;

public interface IEmployeesRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
}