namespace VisualRiders.PointOfSale.Project.Models;

public class ClientLoyalty
{
    public int ClientId { get; set; }
    public Client Client { get; set; }
    
    public int LoyaltyId { get; set; }
    public Loyalty Loyalty { get; set; }
    
    public string CardNumber { get; set; }
}