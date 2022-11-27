using AutoMapper;
using AutoMapper.Features;
using SpaceOut.BusinessLogicLayer.Models.DTOs.NasaApi;
using SpaceOut.BusinessLogicLayer.Services;
using SpaceOut.DataAccessLayer.Models.Entities.NasaApi;
using SpaceOut.Shared.Models.Responses;
using System.Reflection;
using System;

namespace SpaceOut.BusinessLogicLayer;

public class AutoMapperManagement : Profile
{
    public AutoMapperManagement()
    {
        CreateMap<ApodRequestEntity, ApodRequestDto>().ReverseMap();
        CreateMap<ApodResponseEntity, ApodResponseDto>().ReverseMap();

        CreateMap<MarsRoverManifestRequestEntity, MarsRoverManifestRequestDto>().ReverseMap();
        CreateMap<MarsRoverManifestResponseEntity, MarsRoverManifestResponseDto>().ReverseMap();
        CreateMap<MarsRoverPhotoManifestEntity, MarsRoverPhotoManifestDto>().ReverseMap();
        CreateMap<MarsRoverPhotosEntity, MarsRoverPhotosDto>().ReverseMap();

        CreateMap<MarsRoverDateCameraPhotoListRequestEntity, MarsRoverDateCameraPhotoListRequestDto>().ReverseMap();
        CreateMap<MarsRoverDateCameraPhotoListResponseEntity, MarsRoverDateCameraPhotoListResponseDto>().ReverseMap();
        CreateMap<MarsRoverDateCameraPhotoEntity, MarsRoverDateCameraPhotoDto>().ReverseMap();
        CreateMap<MarsRoverCameraDataEntity, MarsRoverCameraDataDto>().ReverseMap();
        CreateMap<MarsRoverDataEntity, MarsRoverDataDto>().ReverseMap();
    }
}
