using System.ComponentModel.DataAnnotations;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateTaxDto
{
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public TaxType Type { get; set; }
    
    [Required]
    [Range(0.0, 100.0)]
    public decimal Percentage { get; set; }
}