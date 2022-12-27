using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class ProductsRepository : RepositoryBase<Product>
{
    public ProductsRepository(PointOfSaleContext context) : base(context)
    {
    }
}