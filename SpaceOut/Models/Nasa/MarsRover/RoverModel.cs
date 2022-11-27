using System.ComponentModel.DataAnnotations;

namespace SpaceOut.UI.Models.Nasa.MarsRover;

public class RoverModel
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
