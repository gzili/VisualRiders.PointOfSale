using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadInventoryDto
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }
    
    public DateTime LastRefill { get; set; }
    
    public int Quantity { get; set; }
}