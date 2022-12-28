using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class LoyaltiesRepository : RepositoryBase<Loyalty>
{
    public LoyaltiesRepository(PointOfSaleContext context) : base(context)
    {
    }
}