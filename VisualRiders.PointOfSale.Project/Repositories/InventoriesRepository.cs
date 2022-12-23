using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class InventoriesRepository : RepositoryBase<Inventory>
{
    public InventoriesRepository(PointOfSaleContext context) : base(context)
    {
    }
}