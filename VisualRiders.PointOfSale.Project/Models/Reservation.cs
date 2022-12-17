namespace VisualRiders.PointOfSale.Project.Models;

public enum ReservationStatus
{
    Active,
    Pending,
    Cancelled
}

public class Reservation
{
    public int Id { get; set; }
    
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    
    public DateTime ReservationStart { get; set; }
    
    public ReservationStatus Status { get; set; }
    
    public int ClientId { get; set; }
    public Client Client { get; set; }
}