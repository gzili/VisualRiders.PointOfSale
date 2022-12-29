using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class ClientLoyaltiesRepository : RepositoryBase<ClientLoyalty>
{
    public ClientLoyaltiesRepository(PointOfSaleContext context) : base(context)
    {
    }
}