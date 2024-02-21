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

    // other logic
}