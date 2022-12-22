using System.ComponentModel.DataAnnotations.Schema;

namespace VisualRiders.PointOfSale.Project.Models;

public class Shift
{
    public int Id { get; set; }
    
    public int StaffMemberId { get; set; }

    [NotMapped]
    public StaffMember StaffMember { get; set; }

    public DateOnly StartDate { get; set; }
    
    public DateOnly EndDate { get; set; }
}