using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class InventoriesProfile : Profile
{
    public InventoriesProfile()
    {
        CreateMap<CreateInventoryDto, Inventory>(MemberList.Source);
        CreateMap<Inventory, ReadInventoryDto>(MemberList.Destination);
    }
}