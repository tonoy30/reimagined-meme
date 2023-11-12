using System.Linq.Expressions;
using RecapApi.Contracts;
using RecapApi.Entities;

namespace RecapApi.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}