using System.ComponentModel.DataAnnotations;

namespace SpaceOut.UI.Models.Nasa.APOD;

public class CountModel
{
    [Required]
    [Range(1, 10, ErrorMessage = "Number of random APODs must be betweeen 1 and 10.")]
    public int Count { get; set; }
}
