using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class DiscountsRepository : RepositoryBase<Discount>
{
    public DiscountsRepository(PointOfSaleContext context) : base(context)
    {
    }
}