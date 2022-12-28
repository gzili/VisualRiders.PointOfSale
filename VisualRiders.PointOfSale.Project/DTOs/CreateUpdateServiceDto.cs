using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateServiceDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    [Range(0, Double.PositiveInfinity)]
    public decimal Cost { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public string Description { get; set; }

    //TODO: Photo

    [Required]
    public int CategoryId { get; set; }

    //TODO: why double?
    [Required]
    public double Duration { get; set; }

    public int? TaxId { get; set; }
}
