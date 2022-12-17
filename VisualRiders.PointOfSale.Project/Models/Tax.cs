namespace VisualRiders.PointOfSale.Project.Models;

public enum TaxType
{
    Individual,
    Categorical,
    Global
}

public class Tax
{
    public int Id { get; set; }
    
    public int BusinessEntityId { get; set; }
    public BusinessEntity BusinessEntity { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public TaxType Type { get; set; }
    
    public decimal Percentage { get; set; }
}