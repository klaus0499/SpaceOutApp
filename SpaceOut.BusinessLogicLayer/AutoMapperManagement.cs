using AutoMapper;
using SpaceOut.BusinessLogicLayer.Models.DTOs.NasaApi;
using SpaceOut.DataAccessLayer.Models.Entities.NasaApi;

namespace SpaceOut.BusinessLogicLayer;

public class AutoMapperManagement : Profile
{
    public AutoMapperManagement()
    {
        CreateMap<ApodRequestEntity, ApodRequestDto>().ReverseMap();
        CreateMap<ApodResponseEntity, ApodResponseDto>().ReverseMap();
    }
}