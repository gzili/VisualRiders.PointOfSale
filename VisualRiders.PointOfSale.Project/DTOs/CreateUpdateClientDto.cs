using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateClientDto
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string PhoneNum { get; set; }

    public string Email { get; set; }

    // public string Password { get; set; }

    public int? ClientLoyaltyId { get; set; }
}