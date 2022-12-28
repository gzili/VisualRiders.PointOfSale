using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        CreateMap<UpdateInventoryDto, Inventory>(MemberList.Source);
        CreateMap<Inventory, ReadInventoryDto>();
    }
}