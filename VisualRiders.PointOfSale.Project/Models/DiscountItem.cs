namespace VisualRiders.PointOfSale.Project.Models;

public class DiscountItem
{
    public int Id { get; set; }
    
    public int DiscountId { get; set; }
    public Discount Discount { get; set; }
    
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    public int? ServiceId { get; set; }
    public Service? Service { get; set; }
    
    public decimal DiscountSize { get; set; }
}