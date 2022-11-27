using System.ComponentModel.DataAnnotations;

namespace SpaceOut.UI.Models.Nasa.APOD;

public class DateModel
{
    [Required]
    public DateTime Date { get; set; }
}
