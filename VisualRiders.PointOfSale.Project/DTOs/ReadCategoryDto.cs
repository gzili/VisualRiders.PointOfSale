using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadCategoryDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    public int? TaxId { get; set; }
}