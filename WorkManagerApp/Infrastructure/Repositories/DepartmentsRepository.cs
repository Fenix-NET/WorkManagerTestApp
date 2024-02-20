using Core.Entities.Models;
using Core.Entities.RequestParametrs;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Infrastructure.Repositories;

public class DepartmentsRepository : RepositoryBase<Department>, IDepartmentsRepository
{
    public DepartmentsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    //public async Task AssignTaskAsync(DepartmentAssignParams param)
    //{
    //    var employees = FindAll().Where(d => d.Name == param.department)
    //        .Include(d => d.Employees).Where(e => e.Employees.)
    //}
}