using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class CategoriesRepository : RepositoryBase<Category>
{
    public CategoriesRepository(PointOfSaleContext context) : base(context)
    {
    }
}