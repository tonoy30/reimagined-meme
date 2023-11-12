using RecapApi.Contracts;
using RecapApi.Entities;

namespace RecapApi.Repositories;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}