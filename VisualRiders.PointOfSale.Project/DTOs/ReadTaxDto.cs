using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadTaxDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public TaxType Type { get; set; }
    
    public decimal Percentage { get; set; }
}