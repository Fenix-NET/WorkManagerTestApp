namespace Core.Interfaces.Repository
{
    public interface IRepositoryManager
    {
        IEmployeesRepository Employees { get; }
        IDepartmentsRepository Departments { get; }
        Task SaveAsync();
    }
}
