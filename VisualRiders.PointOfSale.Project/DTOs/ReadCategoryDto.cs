using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadCategoryDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int? TaxId { get; set; }
}