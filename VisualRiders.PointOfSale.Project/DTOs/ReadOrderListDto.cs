using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadOrderListDto
{
    public int Id { get; set; }

    public DateTime TimeCreated { get; set; }
    
    public OrderStatus Status { get; set; }
    
    public decimal Tips { get; set; }
    
    public decimal Total { get; set; }

    public int? ClientId { get; set; }
}