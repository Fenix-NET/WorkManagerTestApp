using AutoMapper;
using Core.Entities.Dtos;
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

    public async Task<IEnumerable<EmloyeeDto>> GetEmployeesAsync(string? department, bool? busy)
    {
        var employees = await _repository.Employees.GetEmployeesAsync(department, busy);

        var productsDto = _mapper.Map<IEnumerable<EmloyeeDto>>(employees);
        return productsDto;
    }
}