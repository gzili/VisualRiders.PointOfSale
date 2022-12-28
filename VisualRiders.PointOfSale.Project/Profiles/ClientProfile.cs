using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<CreateUpdateClientDto, Client>(MemberList.Source);
        CreateMap<Client, ReadClientDto>(MemberList.Destination);
    }
    
}