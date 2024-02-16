using AutoMapper;
using Core.Interfaces;
using Core.Interfaces.Repository;

namespace Core.Services;

public class EmployeesService : IEmployeesService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public EmployeesService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}