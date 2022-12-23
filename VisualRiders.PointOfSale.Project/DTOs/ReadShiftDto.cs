namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadShiftDto
{
    public int Id { get; set; }
    
    public int StaffMemberId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}