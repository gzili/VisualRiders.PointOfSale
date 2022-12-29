using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class ServicesRepository : RepositoryBase<Service>
{
    public ServicesRepository(PointOfSaleContext context) : base(context)
    {
    }
}
