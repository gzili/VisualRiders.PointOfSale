using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadClientDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string PhoneNum { get; set; }

    public string Email { get; set; }

    public int? ClientLoyaltyId { get; set; }
}