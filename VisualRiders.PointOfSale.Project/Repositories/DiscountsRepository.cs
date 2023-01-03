using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class DiscountsRepository : RepositoryBase<Discount>
{
    public DiscountsRepository(PointOfSaleContext context) : base(context)
    {
    }

    public Discount? GetByCode(string code)
    {
        return Items.FirstOrDefault(i => i.Code == code);
    }
}