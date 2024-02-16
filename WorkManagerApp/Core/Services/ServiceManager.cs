using AutoMapper;
using Core.Interfaces;
using Core.Interfaces.Repository;

namespace Core.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeesService> _employeesService;

    private readonly Lazy<IDepartmentsService> _departmentsService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _employeesService = new Lazy<IEmployeesService>(() =>
            new EmployeesService(repositoryManager, mapper));

        _departmentsService = new Lazy<IDepartmentsService>(() =>
            new DepartmentsService(repositoryManager));
    }

    public IEmployeesService EmployeesService => _employeesService.Value;

    public IDepartmentsService DepartmentsService => _departmentsService.Value;

}