namespace Core.Interfaces;

public interface IServiceManager
{
    IEmployeesService EmployeesService { get; }

    IDepartmentsService DepartmentsService { get; }
}