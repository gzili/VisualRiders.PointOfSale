namespace VisualRiders.PointOfSale.Project.Models;

public class Category
{
    public int Id { get; set; }
    
    public int BusinessEntityId { get; set; }
    public BusinessEntity BusinessEntity { get; set; }
    
    public string Name { get; set; }
    
    public int? TaxId { get; set; }
    public Tax? Tax { get; set; }
}