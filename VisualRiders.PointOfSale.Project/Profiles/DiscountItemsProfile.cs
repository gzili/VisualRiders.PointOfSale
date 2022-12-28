using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class DiscountItemsProfile : Profile
{
    public DiscountItemsProfile()
    {
        CreateMap<CreateUpdateDiscountItemDto, DiscountItem>();
        CreateMap<DiscountItem, ReadDiscountItemDto>();
    }
}
