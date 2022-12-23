using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class ShiftsRepository : RepositoryBase<Shift>
{
    public ShiftsRepository(PointOfSaleContext context) : base(context)
    {

    }
}