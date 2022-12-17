namespace VisualRiders.PointOfSale.Project.Models;

public class StaffMember
{
    public int Id { get; set; }
    
    public int BusinessEntityId { get; set; }
    public BusinessEntity BusinessEntity { get; set; }
    
    public string Occupancy { get; set; }
    
    public string SocSecNum { get; set; }
    
    public DateOnly StartedFrom { get; set; }
    
    public string BankAcc { get; set; }
    
    public string PhoneNum { get; set; }
    
    public string Username { get; set; }
    
    // public string Password { get; set; }
}