using AutoMapper;
using RecapApi.Contracts;

namespace RecapApi.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICompanyService> _companyService;
    private readonly Lazy<IEmployeeService> _employeeService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, mapper));
        _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, mapper));
    }

    public ICompanyService CompanyService => _companyService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;
}