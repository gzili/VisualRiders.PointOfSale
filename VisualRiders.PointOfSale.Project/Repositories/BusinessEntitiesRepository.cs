using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class BusinessEntitiesRepository : RepositoryBase<BusinessEntity>
{
    public BusinessEntitiesRepository(PointOfSaleContext context) : base(context)
    {
    }
}