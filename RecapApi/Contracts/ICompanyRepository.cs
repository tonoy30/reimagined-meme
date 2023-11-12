using RecapApi.Entities;

namespace RecapApi.Contracts;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
}