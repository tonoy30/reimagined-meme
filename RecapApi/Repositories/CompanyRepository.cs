using Microsoft.EntityFrameworkCore;
using RecapApi.Contracts;
using RecapApi.Entities;

namespace RecapApi.Repositories;

public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .Include(c => c.Employees)
            .ToListAsync();
    }
}