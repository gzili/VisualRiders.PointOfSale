using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class InventoryRepository : RepositoryBase<Inventory>
{
    public InventoryRepository(PointOfSaleContext context) : base(context)
    {
    }

    public Inventory? GetByProductId(int productId)
    {
        return Items.FirstOrDefault(i => i.ProductId == productId);
    }
}