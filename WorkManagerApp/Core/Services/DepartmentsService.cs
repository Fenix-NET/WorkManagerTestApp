using AutoMapper;
using Core.Entities.RequestParametrs;
using Core.Interfaces;
using Core.Interfaces.Repository;

namespace Core.Services;

public class DepartmentsService : IDepartmentsService
{
    private readonly IRepositoryManager _repository;

    public DepartmentsService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    //public async Task AssignTaskAsync(DepartmentAssignParams param)
    //{
    //    var employees = await _repository.Employees.
        
    //    await _repository.Departments.AssignTaskAsync(param);
    //}
}