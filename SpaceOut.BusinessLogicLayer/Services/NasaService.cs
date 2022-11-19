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
        ApodResponseDto apodResponseDto = new ApodResponseDto();

        ApodRequestEntity apodRequestEntity = _mapper.Map<ApodRequestEntity>(apodRequestDto);
        ApodResponseEntity apodResponseEntity = await _nasaRepo.GetApod(apodRequestEntity);
        apodResponseDto = _mapper.Map<ApodResponseDto>(apodResponseEntity);

        return apodResponseDto;

    }
}
