using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateLoyaltyDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int DiscountId { get; set; }
}
