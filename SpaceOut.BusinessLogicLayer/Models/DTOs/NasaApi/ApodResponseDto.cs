using SpaceOut.Shared.Models.Responses;

namespace SpaceOut.BusinessLogicLayer.Models.DTOs.NasaApi;

public class ApodResponseDto : OperationResultResponse
{
    public string Copyright { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Explanation { get; set; } = string.Empty;
    public string HdUrl { get; set; } = string.Empty;
    public string Media_Type { get; set; } = string.Empty;
    public string Service_Version { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
