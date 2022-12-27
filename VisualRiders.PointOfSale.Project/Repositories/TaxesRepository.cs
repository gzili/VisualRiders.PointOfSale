using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class TaxesRepository : RepositoryBase<Tax>
{
    public TaxesRepository(PointOfSaleContext context) : base(context)
    {
    }
}