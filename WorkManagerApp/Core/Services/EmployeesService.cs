using AutoMapper;
using Core.Entities.Dtos;
using Core.Entities.Models;
using Core.Entities.RequestParametrs;
using Core.Interfaces;
using Core.Interfaces.Repository;
using System.Globalization;

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

    public async Task<Employee> GetBusyEmployeeAsync(Guid Id)
    {
        
        var employee = await _repository.Employees.GetEmployeeAsync(Id);

        return employee;

    }

    public async Task<Employee> GetUnEmployees(DepartmentAssignParams param)
    {
        var employees = await _repository.Employees.GetUnEmployees(param);

        TimeSpan timeDifference = TimeSpan.MaxValue;
        Employee selectEmployee = null;

        foreach (var employee in employees)
        {
            string[] workHours = employee.Timespan.Split('-');
            DateTime startTime = DateTime.Parse(workHours[0].Trim());
            DateTime endTime = DateTime.Parse(workHours[1].Trim());

            if (param.StartAt > startTime && param.StartAt < endTime)
            {
                TimeSpan tempTimeDifference = endTime - param.StartAt;

                if (tempTimeDifference < timeDifference)
                {
                    selectEmployee = employee;
                    timeDifference = tempTimeDifference;
                }
            }
        } 

        return selectEmployee;
    }

    public async Task AssignTask(Employee employee)
    {
        await _repository.Employees.EmployeeAssign(employee);

        await _repository.SaveAsync();
    }
}