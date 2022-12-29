using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateDiscountDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public string Code { get; set; } = "";
}