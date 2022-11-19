namespace SpaceOut.BusinessLogicLayer.Models.DTOs.NasaApi;

public class ApodRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Count { get; set; } = 0;
    public bool Thumbs { get; set; } = false;
}
