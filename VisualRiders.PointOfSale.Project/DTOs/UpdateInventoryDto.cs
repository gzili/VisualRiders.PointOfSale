using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class UpdateInventoryDto
{
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public DateTime LastRefill { get; set; }
}