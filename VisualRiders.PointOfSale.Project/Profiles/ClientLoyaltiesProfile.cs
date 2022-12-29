using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class ClientLoyaltiesProfile : Profile
{
    public ClientLoyaltiesProfile()
    {
        CreateMap<CreateUpdateClientLoyaltyDto, ClientLoyalty>();
    }
}