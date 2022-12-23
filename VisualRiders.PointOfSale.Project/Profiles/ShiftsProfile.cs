using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class ShiftsProfile : Profile
{
    public ShiftsProfile()
    {
        CreateMap<CreateUpdateShiftDto, Shift>(MemberList.Source);
        CreateMap<Shift, ReadShiftDto>();
    }
}