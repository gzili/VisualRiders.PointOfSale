using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class OrderItemsRepository : RepositoryBase<OrderItem>
{
    public OrderItemsRepository(PointOfSaleContext context) : base(context)
    {
    }

    public List<OrderItem> GetByOrderId(int orderId)
    {
        return Items.Where(i => i.OrderId == orderId).ToList();
    }
}