using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateCategoryDto
{
    [Required]
    public string Name { get; set; }
    
    public int? TaxId { get; set; }
}