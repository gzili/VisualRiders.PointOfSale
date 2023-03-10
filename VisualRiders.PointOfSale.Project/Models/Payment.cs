namespace VisualRiders.PointOfSale.Project.Models;

public enum PaymentStatus
{
    Pending,
    Cancelled,
    Completed
}

public enum PaymentMethod
{
    Card,
    Cash
}

public class Payment
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public PaymentMethod Method { get; set; }
    
    public PaymentStatus Status { get; set; }

    public decimal Amount { get; set; }

    public decimal Change { get; set; }
}