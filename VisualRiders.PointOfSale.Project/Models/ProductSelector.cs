namespace VisualRiders.PointOfSale.Project.Models;

public class ProductSelector
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int ItemSelectionId { get; set; }
    public ItemSelection ItemSelection { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Type { get; set; }
}