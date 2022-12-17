namespace VisualRiders.PointOfSale.Project.Models;

public class OrderItem
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public int? ItemSelectionValueId { get; set; }
    public ItemSelectionValue? ItemSelectionValue { get; set; }
    
    public decimal ItemQuantity { get; set; }
    
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    public int? ServiceId { get; set; }
    public Service? Service { get; set; }
}