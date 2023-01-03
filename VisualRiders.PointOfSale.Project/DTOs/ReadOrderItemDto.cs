namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadOrderItemDto
{
    public int Id { get; set; }

    public decimal Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal DiscountRate { get; set; }
    
    public decimal TaxRate { get; set; }
    
    public decimal DiscountTotal { get; set; }
    
    public decimal TaxAmount { get; set; }
    
    public decimal Subtotal { get; set; }
    
    public decimal Total { get; set; }
    
    public int? ProductId { get; set; }
    
    public int? ServiceId { get; set; }
}