using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class PaymentsProfile : Profile
{
    public PaymentsProfile()
    {
        CreateMap<CreatePaymentDto, Payment>(MemberList.Source);
        CreateMap<Payment, ReadPaymentDto>();
    }
}