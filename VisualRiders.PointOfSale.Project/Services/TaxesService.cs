using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class TaxesService
{
    private readonly TaxesRepository _repository;
    private readonly IMapper _mapper;

    public TaxesService(TaxesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReadTaxDto Create(CreateUpdateTaxDto dto)
    {
        var taxesEntity = _mapper.Map<Tax>(dto);

        taxesEntity.BusinessEntityId = 1;
        
        _repository.Add(taxesEntity);
        _repository.SaveChanges();

        return _mapper.Map<ReadTaxDto>(taxesEntity);
    }

    public List<ReadTaxDto> GetAll()
    {
        return _repository.GetAll().Select((tax) => _mapper.Map<ReadTaxDto>(tax)).ToList();
    }

    public ReadTaxDto? GetById(int id)
    {
        return _mapper.Map<ReadTaxDto>(_repository.GetById(id));
    }
    
    public ReadTaxDto? UpdateById(int id, CreateUpdateTaxDto dto)
    {
        var taxesEntity = _repository.GetById(id);

        if (taxesEntity is null)
        {
            return null;
        }

        taxesEntity.Name = dto.Name;
        taxesEntity.Description = dto.Description;
        taxesEntity.Percentage = dto.Percentage;
        taxesEntity.Type = dto.Type;

        _repository.SaveChanges();

        return _mapper.Map<ReadTaxDto>(taxesEntity);
    }

    public bool RemoveById(int id)
    {
        var taxesEntity = _repository.GetById(id);

        if (taxesEntity is null)
        {
            return false;
        }
        
        _repository.Remove(taxesEntity);
        _repository.SaveChanges();

        return true;
    }
}