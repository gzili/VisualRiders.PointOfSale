using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class PaymentsRepository : RepositoryBase<Payment>
{
    public PaymentsRepository(PointOfSaleContext context) : base(context)
    {
    }

    public List<Payment> FindByOrderId(int orderId)
    {
        return Items.Where(i => i.OrderId == orderId).ToList();
    }
}