using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class TaxesProfile : Profile
{
    public TaxesProfile()
    {
        CreateMap<CreateUpdateTaxDto, Tax>(MemberList.Source);
        CreateMap<Tax, ReadTaxDto>(MemberList.Destination);
    }
    
}