using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class DiscountCodeDto
{
    [Required]
    public string Code { get; set; }
}