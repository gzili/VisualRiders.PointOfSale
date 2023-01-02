using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class OrderItemsProfile : Profile
{
    public OrderItemsProfile()
    {
        CreateMap<CreateOrderItemDto, OrderItem>(MemberList.Source);
        CreateMap<OrderItem, ReadOrderItemDto>();
        CreateMap<UpdateOrderItemDto, OrderItem>(MemberList.Source);
    }
}