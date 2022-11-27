using AutoMapper;
using SpaceOut.BusinessLogicLayer.Models.DTOs.NasaApi;
using SpaceOut.DataAccessLayer.Models.Entities.NasaApi;
using SpaceOut.DataAccessLayer.Repositories;


namespace SpaceOut.BusinessLogicLayer.Services;

public class NasaService
{
    private readonly NasaRepository _nasaRepo;
    private IMapper _mapper { get; set; }

    public NasaService(NasaRepository nasaRepo, IMapper mapper)
	{
        _nasaRepo= nasaRepo;
        _mapper= mapper;
	}

    public async Task<ApodResponseDto> GetApod(ApodRequestDto apodRequestDto)
    {
        ApodRequestEntity apodRequestEntity = _mapper.Map<ApodRequestEntity>(apodRequestDto);
        ApodResponseEntity apodResponseEntity = await _nasaRepo.GetApod(apodRequestEntity);
        ApodResponseDto apodResponseDto = _mapper.Map<ApodResponseDto>(apodResponseEntity);
        return apodResponseDto;
    }

    public async Task<List<ApodResponseDto>> GetApodCount(ApodRequestDto apodRequestDto)
    {
        ApodRequestEntity apodRequestEntity = _mapper.Map<ApodRequestEntity>(apodRequestDto);
        List<ApodResponseEntity> apodResponseEntityList = await _nasaRepo.GetApodCount(apodRequestEntity);
        List<ApodResponseDto> apodResponseDtoList = _mapper.Map<List<ApodResponseDto>>(apodResponseEntityList);
        return apodResponseDtoList;
    }

    public async Task<MarsRoverManifestResponseDto> GetMarsRoverManifest(MarsRoverManifestRequestDto marsRoverManifestRequestDto)
    {
        MarsRoverManifestRequestEntity marsRoverManifestRequestEntity = _mapper.Map<MarsRoverManifestRequestEntity>(marsRoverManifestRequestDto);
        MarsRoverManifestResponseEntity marsRoverManifestResponseEntity = await _nasaRepo.GetMarsRoverManifest(marsRoverManifestRequestEntity);
        MarsRoverManifestResponseDto marsRoverManifestResponseDto = _mapper.Map<MarsRoverManifestResponseDto>(marsRoverManifestResponseEntity);
        return marsRoverManifestResponseDto;
    }

    public async Task<MarsRoverDateCameraPhotoListResponseDto> GetMarsRoverDateCameraPhotoList(MarsRoverDateCameraPhotoListRequestDto marsRoverDateCameraPhotoListRequestDto)
    {
        MarsRoverDateCameraPhotoListRequestEntity marsRoverDateCameraPhotoListRequestEntity = _mapper.Map<MarsRoverDateCameraPhotoListRequestEntity>(marsRoverDateCameraPhotoListRequestDto);
        MarsRoverDateCameraPhotoListResponseEntity marsRoverDateCameraPhotoListResponseEntity = await _nasaRepo.GetMarsRoverDateCameraPhotoList(marsRoverDateCameraPhotoListRequestEntity);
        MarsRoverDateCameraPhotoListResponseDto marsRoverDateCameraPhotoListResponseDto = _mapper.Map<MarsRoverDateCameraPhotoListResponseDto>(marsRoverDateCameraPhotoListResponseEntity);
        return marsRoverDateCameraPhotoListResponseDto;
    }
}
