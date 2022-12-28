using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class DiscountsProfile : Profile
{
    public DiscountsProfile()
    {
        CreateMap<CreateUpdateDiscountDto, Discount>();
        CreateMap<Discount, ReadDiscountDto>();
    }
}
