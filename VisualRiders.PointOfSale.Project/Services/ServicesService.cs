using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class ServicesService
{
    private readonly CategoriesRepository _categoriesRepository;
    private readonly TaxesRepository _taxesRepository;
    private readonly ServicesRepository _repository;
    private readonly IMapper _mapper;

    public ServicesService(
        CategoriesRepository categoriesRepository,
        TaxesRepository taxesRepository,
        ServicesRepository repository,
        IMapper mapper)
    {
        _categoriesRepository = categoriesRepository;
        _taxesRepository = taxesRepository;
        _repository = repository;
        _mapper = mapper;
    }

    public ReadServiceDto Create(CreateUpdateServiceDto dto)
    {
        var service = _mapper.Map<Service>(dto);

        service.BusinessEntityId = 1;

        var category = _categoriesRepository.GetById(dto.CategoryId);

        if (category == null)
        {
            throw new UnprocessableEntity($"Category with Id = {dto.CategoryId} does not exist");
        }

        service.Category = category;
        
        if (dto.TaxId != null)
        {
            var tax = _taxesRepository.GetById(dto.TaxId.Value);

            if (tax == null)
            {
                throw new UnprocessableEntity($"Tax with Id = {dto.TaxId.Value} does not exist");
            }
            service.Tax = tax;
        }

        _repository.Add(service);
        _repository.SaveChanges();

        return _mapper.Map<ReadServiceDto>(service);
    }

    public List<ReadServiceDto> GetAll()
    {
        return _repository.GetAll().Select(_mapper.Map<ReadServiceDto>).ToList();
    }

    public ReadServiceDto? GetById(int id)
    {
        return _mapper.Map<ReadServiceDto>(_repository.GetById(id));
    }

    public ReadServiceDto? UpdateById(int id, CreateUpdateServiceDto dto)
    {
        var service = _repository.GetById(id);

        if (service == null) return null;

        _mapper.Map(dto, service);

        var category = _categoriesRepository.GetById(dto.CategoryId);

        if (category == null)
        {
            throw new UnprocessableEntity($"Category with Id = {dto.CategoryId} does not exist");
        }

        service.Category = category;
        
        if (dto.TaxId != null)
        {
            var tax = _taxesRepository.GetById(dto.TaxId.Value);

            if (tax == null)
            {
                throw new UnprocessableEntity($"Tax with Id = {dto.TaxId.Value} does not exist");
            }

            service.Tax = tax;
        }
        else
        {
            service.Tax = null;
        }

        _repository.SaveChanges();

        return _mapper.Map<ReadServiceDto>(service);
    }

    public bool RemoveById(int id)
    {
        var service = _repository.GetById(id);

        if (service == null) return false;

        _repository.Remove(service);
        _repository.SaveChanges();

        return true;
    }
}