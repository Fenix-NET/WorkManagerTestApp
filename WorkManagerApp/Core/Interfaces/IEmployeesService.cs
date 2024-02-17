using Core.Entities.Dtos;

namespace Core.Interfaces;

public interface IEmployeesService
{
    public Task<IEnumerable<EmloyeeDto>> GetEmployeesAsync(string? department, bool? busy);
}