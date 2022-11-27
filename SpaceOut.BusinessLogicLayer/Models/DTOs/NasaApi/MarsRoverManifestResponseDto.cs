using SpaceOut.Shared.Models.Responses;

namespace SpaceOut.BusinessLogicLayer.Models.DTOs.NasaApi;

public class MarsRoverManifestResponseDto : OperationResultResponse
{
    public MarsRoverPhotoManifestDto? Photo_Manifest { get; set; }
}

public class MarsRoverPhotoManifestDto
{
    public string Name { get; set; } = string.Empty;
    public string Landing_Date { get; set; } = string.Empty;
    public string Launch_Date { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Max_Sol { get; set; } = 0;
    public string Max_Date { get; set; } = string.Empty;
    public int Total_Photos { get; set; } = 0;
    public List<MarsRoverPhotosDto> Photos { get; set; } = new List<MarsRoverPhotosDto>();
}

public class MarsRoverPhotosDto
{
    public int Sol { get; set; } = 0;
    public string Earth_Date { get; set; } = string.Empty;
    public int Total_Photos { get; set; } = 0;
    public List<string>? Cameras { get; set; }
}
