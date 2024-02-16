using Core.Entities;
using Core.Interfaces.Repository;

namespace Infrastructure.Repositories;

public class DepartmentsRepository : RepositoryBase<Department>, IDepartmentsRepository
{
    public DepartmentsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}