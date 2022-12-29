using System.ComponentModel.DataAnnotations;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateClientLoyaltyDto
{
    [Required]
    public int LoyaltyId { get; set; }

    [Required]
    public string CardNumber { get; set; }
}