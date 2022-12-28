using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class ClientsRepository : RepositoryBase<Client>
{
    public ClientsRepository(PointOfSaleContext context) : base(context)
    {
    }
}