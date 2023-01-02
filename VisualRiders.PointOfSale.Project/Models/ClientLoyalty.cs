using System.Text.Json.Serialization;

namespace VisualRiders.PointOfSale.Project.Models;

public class ClientLoyalty
{
    public int Id { get; set; }
    
    public int LoyaltyId { get; set; }
    
    [JsonIgnore]
    public Loyalty Loyalty { get; set; }

    public string CardNumber { get; set; }
}