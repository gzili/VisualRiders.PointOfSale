namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateOrderDto
{
    public int? ClientId { get; set; }

    public List<CreateOrderItemDto> Items { get; set; }    
}