using AutoMapper;
using DaDataTestService.DTO;
using DaDataTestService.Models;

namespace DaDataTestService.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto, Address>();
    }
}