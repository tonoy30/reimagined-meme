using AutoMapper;
using RecapApi.Contracts;
using RecapApi.Repositories;

namespace RecapApi.Services;

public sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public EmployeeService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
}