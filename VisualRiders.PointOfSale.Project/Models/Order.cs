namespace VisualRiders.PointOfSale.Project.Models;

public enum OrderStatus
{
    Created,
    Seen,
    InProgress,
    Cancelled,
    InDelivery,
    Delivered
}

public class Order
{
    public int Id { get; set; }
    
    public int BusinessEntityId { get; set; }
    public BusinessEntity BusinessEntity { get; set; }
    
    public DateTime TimeCreated { get; set; }
    
    public OrderStatus Status { get; set; }
    
    public decimal Tips { get; set; }
    
    public decimal Subtotal { get; set; }
    
    public decimal DiscountTotal { get; set; }
    
    public decimal TaxTotal { get; set; }
    
    public decimal Total { get; set; }

    public int? ClientId { get; set; }
    public Client? Client { get; set; }
    
    
    public List<OrderItem> Items { get; set; }
}