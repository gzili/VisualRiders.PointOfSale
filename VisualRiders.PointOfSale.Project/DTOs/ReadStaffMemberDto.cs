namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadStaffMemberDto
{
    public int Id { get; set; }

    public string Occupancy { get; set; }
    
    public string SocSecNum { get; set; }
    
    public DateOnly StartedFrom { get; set; }
    
    public string BankAcc { get; set; }
    
    public string PhoneNum { get; set; }
    
    public string Username { get; set; }
}