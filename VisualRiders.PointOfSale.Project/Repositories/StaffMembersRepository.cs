using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class StaffMembersRepository : RepositoryBase<StaffMember>
{
    public StaffMembersRepository(PointOfSaleContext context) : base(context)
    {
    }
}