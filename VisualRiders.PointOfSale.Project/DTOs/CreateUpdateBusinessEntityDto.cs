using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateBusinessEntityDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Code { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Address { get; set; }
}