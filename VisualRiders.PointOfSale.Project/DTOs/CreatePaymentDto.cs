using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.DTOs;

public class CreatePaymentDto
{
    public int OrderId { get; set; }

    public PaymentMethod Method { get; set; }
    
    public decimal Amount { get; set; }
}