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
        var tax = _mapper.Map<Tax>(dto);

        tax.BusinessEntityId = 1;
        
        _repository.Add(tax);
        _repository.SaveChanges();

        return _mapper.Map<ReadTaxDto>(tax);
    }

    public List<ReadTaxDto> GetAll()
    {
        return _repository.GetAll().Select(_mapper.Map<ReadTaxDto>).ToList();
    }

    public ReadTaxDto? GetById(int id)
    {
        return _mapper.Map<ReadTaxDto>(_repository.GetById(id));
    }
    
    public ReadTaxDto? UpdateById(int id, CreateUpdateTaxDto dto)
    {
        var tax = _repository.GetById(id);

        if (tax is null) return null;

        _mapper.Map(dto, tax);

        _repository.SaveChanges();

        return _mapper.Map<ReadTaxDto>(tax);
    }

    public bool RemoveById(int id)
    {
        var tax = _repository.GetById(id);

        if (tax is null)
        {
            return false;
        }
        
        _repository.Remove(tax);
        _repository.SaveChanges();

        return true;
    }
}