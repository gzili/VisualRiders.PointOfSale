using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateDiscountItemDto
{
    public int? ProductId { get; set; }

    public int? ServiceId { get; set; }

    [Required]
    public decimal DiscountSize { get; set; }
}
