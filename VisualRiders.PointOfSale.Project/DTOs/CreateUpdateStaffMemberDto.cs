using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateStaffMemberDto
{
    [Required]
    public string Occupancy { get; set; }

    [Required]
    public string SocSecNum { get; set; }

    [Required]
    public DateOnly StartedFrom { get; set; }

    [Required]
    public string BankAcc { get; set; }

    [Required]
    public string PhoneNum { get; set; }

    [Required]
    public string Username { get; set; }
}