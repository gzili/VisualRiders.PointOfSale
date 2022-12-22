using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadStaffMemberDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int BusinessEntityId { get; set; }

    [Required]
    public string Occupancy { get; set; }

    [Required]
    public DateOnly StartedFrom { get; set; }

    [Required]
    public string PhoneNum { get; set; }

    [Required]
    public string Username { get; set; }
}