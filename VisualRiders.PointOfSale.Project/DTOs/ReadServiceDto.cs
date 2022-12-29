namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadServiceDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Cost { get; set; }
    
    public bool Available { get; set; }
    
    public string Description { get; set; }
    
    public int CategoryId { get; set; }

    public double Duration { get; set; }
    
    public int? TaxId { get; set; }
}
