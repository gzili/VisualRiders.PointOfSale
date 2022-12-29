namespace VisualRiders.PointOfSale.Project.Models;

public class Discount
{
    public int Id { get; set; }
    
    public int BusinessEntityId { get; set; }
    public BusinessEntity BusinessEntity { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    public string Code { get; set; } = "";
}