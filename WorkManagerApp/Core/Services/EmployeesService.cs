using AutoMapper;
using Core.Entities.Dtos;
using Core.Entities.Models;
using Core.Entities.RequestParametrs;
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

    public async Task<Employee> GetBusyEmployeeAsync(Guid Id)
    {

        var employee = await _repository.Employees.GetEmployeeAsync(Id);

        return employee;

    }

    public async Task<Employee> GetUnEmployees(DepartmentAssignParams param)
    {
        var availableEmployees = await _repository.Employees.GetUnEmployees(param);

        Employee selectEmployee = null;
        TimeSpan shortestTimeDifference = TimeSpan.MaxValue;

        foreach (var employee in availableEmployees)
        {
            string[] workHours = employee.Timespan.Split('-');
            DateTime startTime = DateTime.Parse(workHours[0].Trim());
            DateTime endTime = DateTime.Parse(workHours[1].Trim());

            if (param.StartAt.TimeOfDay >= startTime.TimeOfDay && param.StartAt.TimeOfDay <= endTime.TimeOfDay)
            {
                TimeSpan tempDifference = endTime.TimeOfDay - param.StartAt.TimeOfDay;

                if (tempDifference < shortestTimeDifference)
                {
                    selectEmployee = employee;
                    shortestTimeDifference = tempDifference;
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

    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        return await _repository.Employees.GetEmployeeAsync(id);
    }

    public async Task AssignTaskWithCheck(Employee employee, DateTime dt)
    {
        string[] workHours = employee.Timespan.Split('-');
        DateTime startTime = DateTime.Parse(workHours[0].Trim());
        DateTime endTime = DateTime.Parse(workHours[1].Trim());

        bool isCheck = dt.TimeOfDay > startTime.TimeOfDay && dt.TimeOfDay < endTime.TimeOfDay;

        if (isCheck)
        {
            await AssignTask(employee);
        }
        else
        {
            throw new Exception();
        }
    }
}