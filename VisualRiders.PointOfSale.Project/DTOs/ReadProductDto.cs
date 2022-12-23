using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class ReadProductDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    [Range(0, Double.PositiveInfinity)]
    public decimal Cost { get; set; }
    
    [Required]
    public bool Available { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    // TODO: Photo
    
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string MeasUnit { get; set; }
    
    public int? TaxId { get; set; }

    [Required]
    public bool Returnable { get; set; }
}