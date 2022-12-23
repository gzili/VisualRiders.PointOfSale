using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadInventoryDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public DateTime LastRefill { get; set; }
    
    [Required]
    [Range(0, Double.PositiveInfinity)]
    public int Quantity { get; set; }
}