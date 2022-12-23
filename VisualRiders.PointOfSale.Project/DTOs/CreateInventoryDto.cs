using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateInventoryDto
{
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    [Range(0, Double.PositiveInfinity)]
    public int Quantity { get; set; }
}