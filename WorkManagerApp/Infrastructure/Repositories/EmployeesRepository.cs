using Core.Entities;
using Core.Interfaces.Repository;

namespace Infrastructure.Repositories;

public class EmployeesRepository : RepositoryBase<Employee>, IEmployeesRepository
{
    public EmployeesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        throw new NotImplementedException();
    }
}