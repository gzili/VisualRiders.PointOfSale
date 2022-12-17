namespace VisualRiders.PointOfSale.Project.Models;

public class Service
{
    public int Id { get; set; }
    
    public int BusinessEntityId { get; set; }
    public BusinessEntity BusinessEntity { get; set; }
    
    public string Name { get; set; }
    
    public decimal Cost { get; set; }
    
    public bool Available { get; set; }
    
    public string Description { get; set; }
    
    // TODO: Photo
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    // TODO: why double?
    public double Duration { get; set; }
    
    public int? TaxId { get; set; }
    public Tax? Tax { get; set; }
}