using RecapApi.DTOs;

namespace RecapApi.Contracts;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);
}