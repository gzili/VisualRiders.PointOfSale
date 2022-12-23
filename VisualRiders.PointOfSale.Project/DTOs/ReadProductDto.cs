using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class ReadProductDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Cost { get; set; }
    
    public bool Available { get; set; }

    public string Description { get; set; }
    
    // TODO: Photo
    
    public int CategoryId { get; set; }
    
    public string MeasUnit { get; set; }
    
    public int? TaxId { get; set; }
    
    public bool Returnable { get; set; }
}