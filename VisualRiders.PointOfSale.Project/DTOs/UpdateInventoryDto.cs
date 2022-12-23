using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class UpdateInventoryDto
{
    [Required]
    [Range(0, Double.PositiveInfinity)]
    public int Quantity { get; set; }
}