using AutoMapper;
using RecapApi.Contracts;
using RecapApi.DTOs;
using RecapApi.Repositories;

namespace RecapApi.Services;

public sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public CompanyService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }
}