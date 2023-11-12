using AutoMapper;
using RecapApi.DTOs;
using RecapApi.Entities;

namespace RecapApi.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(d => d.FullAddress,
                opt =>
                    opt.MapFrom(c => $"{c.Address} {c.Country}"));
        CreateMap<Employee, EmployeeDto>();
    }
}