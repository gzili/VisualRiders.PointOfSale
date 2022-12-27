using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Profiles;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<CreateUpdateCategoryDto, Category>();
        CreateMap<Category, ReadCategoryDto>();
    }
}