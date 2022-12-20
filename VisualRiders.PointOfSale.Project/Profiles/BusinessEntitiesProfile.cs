using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class BusinessEntitiesProfile : Profile
{
    public BusinessEntitiesProfile()
    {
        CreateMap<CreateUpdateBusinessEntityDto, BusinessEntity>();
    }
}