using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        CreateMap<CreateUpdateServiceDto, Service>();
        CreateMap<Service, ReadServiceDto>();
    }
}
