using Core.Interfaces.Repository;

namespace Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IEmployeesRepository> _employeesRepository;
        private readonly Lazy<IDepartmentsRepository> _departmentsRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _employeesRepository = new Lazy<IEmployeesRepository>(() =>
            new EmployeesRepository(repositoryContext));

            _departmentsRepository = new Lazy<IDepartmentsRepository>(() =>
            new DepartmentsRepository(repositoryContext));
        }

        public IEmployeesRepository Employees => _employeesRepository.Value;
        public IDepartmentsRepository Departments => _departmentsRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
