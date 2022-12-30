using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class OrdersRepository : RepositoryBase<Order>
{
    public OrdersRepository(PointOfSaleContext context) : base(context)
    {
    }
}