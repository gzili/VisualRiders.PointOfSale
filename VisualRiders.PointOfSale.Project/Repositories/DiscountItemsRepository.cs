using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class DiscountItemsRepository : RepositoryBase<DiscountItem>
{
    public DiscountItemsRepository(PointOfSaleContext context) : base(context)
    {
    }

    public List<DiscountItem> GetByDiscountId(int id)
    {
        return Items.Where(x => x.DiscountId == id).ToList(); 
    }

    public DiscountItem? GetByDiscountIdAndProductId(int discountId, int productId)
    {
        return Items.FirstOrDefault(i => i.DiscountId == discountId && i.ProductId == productId);
    }
}