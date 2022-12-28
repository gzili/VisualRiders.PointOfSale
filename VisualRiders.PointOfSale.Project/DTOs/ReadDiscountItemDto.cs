namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadDiscountItemDto
{
    public int Id { get; set; }
    public int DiscountId { get; set; }
    public int? ProductId { get; set; }
    public int? ServiceId { get; set; }
    public decimal DiscountSize { get; set; }
}
