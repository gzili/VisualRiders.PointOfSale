using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateClientDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public string PhoneNum { get; set; }

    [Required]
    public string Email { get; set; }

    // public string Password { get; set; }

    public int? ClientLoyaltyId { get; set; }
}