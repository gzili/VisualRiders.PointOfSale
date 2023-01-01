using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class OrdersProfile : Profile
{
    public OrdersProfile()
    {
        CreateMap<CreateOrderDto, Order>(MemberList.Source);
        CreateMap<Order, ReadOrderDto>();
        CreateMap<Order, ReadOrderListDto>();
    }
}