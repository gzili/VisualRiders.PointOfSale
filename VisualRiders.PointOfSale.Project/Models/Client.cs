namespace VisualRiders.PointOfSale.Project.Models;

public class Client
{
    public int Id { get; set; }
    
    public int BusinessEntityId { get; set; }
    public BusinessEntity BusinessEntity { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string PhoneNum { get; set; }
    
    public string Email { get; set; }
    
    // public string Password { get; set; }
    
    public int? ClientLoyaltyId { get; set; }
    public ClientLoyalty? ClientLoyalty { get; set; }
}