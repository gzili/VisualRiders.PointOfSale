using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<Product, ReadProductDto>();
    }
}