using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class ReadPaymentDto
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }

    public PaymentMethod Method { get; set; }
    
    public PaymentStatus Status { get; set; }

    public decimal Amount { get; set; }

    public decimal Change { get; set; }
}