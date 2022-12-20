namespace VisualRiders.PointOfSale.Project.Models;

public class Inventory
{
    public int Id { get; set; }
    
    public int BusinessEntityId { get; set; }
    public BusinessEntity BusinessEntity { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public DateTime LastRefill { get; set; }
    
    public int Quantity { get; set; }
}