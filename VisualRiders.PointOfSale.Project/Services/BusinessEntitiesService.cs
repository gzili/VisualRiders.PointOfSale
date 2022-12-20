using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class BusinessEntitiesService
{
    private readonly BusinessEntitiesRepository _repository;
    private readonly IMapper _mapper;

    public BusinessEntitiesService(BusinessEntitiesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public BusinessEntity Create(CreateUpdateBusinessEntityDto dto)
    {
        var businessEntity = _mapper.Map<BusinessEntity>(dto);
        
        _repository.Add(businessEntity);
        _repository.SaveChanges();

        return businessEntity;
    }

    public List<BusinessEntity> GetAll()
    {
        return _repository.GetAll();
    }

    public BusinessEntity? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public BusinessEntity? UpdateById(int id, CreateUpdateBusinessEntityDto dto)
    {
        var businessEntity = _repository.GetById(id);

        if (businessEntity == null) return null;

        businessEntity.Name = dto.Name;
        businessEntity.Code = dto.Code;
        businessEntity.Description = dto.Description;
        businessEntity.Address = dto.Address;
        
        _repository.SaveChanges();

        return businessEntity;
    }

    public bool RemoveById(int id)
    {
        var businessEntity = _repository.GetById(id);

        if (businessEntity == null) return false;
        
        _repository.Remove(businessEntity);
        _repository.SaveChanges();

        return true;
    }
}