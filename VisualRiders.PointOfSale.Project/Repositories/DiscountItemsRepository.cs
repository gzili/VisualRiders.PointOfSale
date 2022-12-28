using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class DiscountItemsRepository : RepositoryBase<DiscountItem>
{
    public DiscountItemsRepository(PointOfSaleContext context) : base(context)
    {
    }

    public List<DiscountItem>? GetItemsByDiscountId(int id)
    {
        return Items.Where(x => x.DiscountId == id).ToList(); 
    }
}