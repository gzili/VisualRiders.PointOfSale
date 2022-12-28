using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class LoyaltiesProfile : Profile
{
    public LoyaltiesProfile()
    {
        CreateMap<CreateUpdateLoyaltyDto, Loyalty>();
        CreateMap<Loyalty, ReadLoyaltyDto>();
    }
}
