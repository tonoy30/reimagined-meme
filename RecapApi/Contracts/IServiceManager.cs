using RecapApi.Services;

namespace RecapApi.Contracts;

public interface IServiceManager
{
    ICompanyService CompanyService { get; }
    IEmployeeService EmployeeService { get; }
    IAuthenticationService AuthenticationService { get; }
}