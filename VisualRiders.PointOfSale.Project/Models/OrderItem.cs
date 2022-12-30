namespace VisualRiders.PointOfSale.Project.Models;

public class OrderItem
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public decimal Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal Total { get; set; }
    
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    public int? ServiceId { get; set; }
    public Service? Service { get; set; }
}