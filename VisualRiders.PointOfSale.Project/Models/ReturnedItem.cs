namespace VisualRiders.PointOfSale.Project.Models;

public class ReturnedItem
{
    public int OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }
    
    public int PaymentId { get; set; }
    public Payment Payment { get; set; }
    
    public string Reason { get; set; }
    
    public decimal ReturnedPrice { get; set; }
    
    public int StaffMemberId { get; set; }
    public StaffMember StaffMember { get; set; }
}