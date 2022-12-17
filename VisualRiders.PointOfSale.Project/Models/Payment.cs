namespace VisualRiders.PointOfSale.Project.Models;

public enum PaymentStatus
{
    Pending,
    Cancelled,
    Paid
}

public class Payment
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public decimal LoyaltyAmount { get; set; }
    
    public decimal DiscountAmount { get; set; }

    public string Delivery { get; set; } = "";

    public string Method { get; set; } = "";
    
    public decimal OrderTotal { get; set; }
    
    public decimal TaxesTotal { get; set; }
    
    public decimal AmountPaid { get; set; }
    
    public PaymentStatus Status { get; set; }
    
    public decimal Change { get; set; }
    
    public int? StaffMemberId { get; set; }
    public StaffMember? StaffMember { get; set; }
}