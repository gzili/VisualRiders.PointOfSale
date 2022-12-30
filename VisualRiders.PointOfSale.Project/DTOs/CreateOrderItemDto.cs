namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateOrderItemDto
{
    public decimal Quantity { get; set; }

    public int? ProductId { get; set; }

    public int? ServiceId { get; set; }
}