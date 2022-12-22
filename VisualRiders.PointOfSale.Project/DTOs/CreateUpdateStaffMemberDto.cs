using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreateUpdateStaffMemberDto
{
    [Required]
    public int BusinessEntityId { get; set; }

    [Required]
    public string Occupancy { get; set; }

    [Required]
    public string SocSecNum { get; set; }

    [Required]
    public DateTime StartedFrom { get; set; }

    [Required]
    public string BankAcc { get; set; }

    [Required]
    public string PhoneNum { get; set; }

    [Required]
    public string Username { get; set; }
}