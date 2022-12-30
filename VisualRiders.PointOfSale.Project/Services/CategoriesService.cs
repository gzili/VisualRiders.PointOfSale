using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class CategoriesService
{
    private readonly CategoriesRepository _repository;
    private readonly TaxesRepository _taxesRepository;
    private readonly IMapper _mapper;

    public CategoriesService(CategoriesRepository repository, TaxesRepository taxesRepository, IMapper mapper)
    {
        _repository = repository;
        _taxesRepository = taxesRepository;
        _mapper = mapper;
    }

    public ReadCategoryDto Create(CreateUpdateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);

        category.BusinessEntityId = 1;

        if (dto.TaxId != null)
        {
            var tax = _taxesRepository.GetById(dto.TaxId.Value);

            if (tax == null)
            {
                throw new UnprocessableEntity($"Tax with Id = {dto.TaxId.Value} does not exist");
            }

            if (tax.Type != TaxType.Categorical)
            {
                throw new UnprocessableEntity($"Cannot assign tax of type `{tax.Type.ToString()}` to a category");
            }

            category.Tax = tax;
        }

        _repository.Add(category);
        _repository.SaveChanges();

        return _mapper.Map<ReadCategoryDto>(category);
    }

    public List<ReadCategoryDto> GetAll()
    {
        return _repository.GetAll().Select(_mapper.Map<ReadCategoryDto>).ToList();
    }

    public ReadCategoryDto? GetById(int id)
    {
        return _mapper.Map<ReadCategoryDto>(_repository.GetById(id));
    }

    public ReadCategoryDto? UpdateById(int id, CreateUpdateCategoryDto dto)
    {
        var category = _repository.GetById(id);

        if (category == null) return null;

        _mapper.Map(dto, category);
        
        if (dto.TaxId != null)
        {
            var tax = _taxesRepository.GetById(dto.TaxId.Value);

            if (tax == null)
            {
                throw new UnprocessableEntity($"Tax with Id = {dto.TaxId.Value} does not exist");
            }
            
            if (tax.Type != TaxType.Categorical)
            {
                throw new UnprocessableEntity($"Cannot assign tax of type `{tax.Type.ToString()}` to a category");
            }

            category.Tax = tax;
        }
        else
        {
            category.Tax = null;
        }
        
        _repository.SaveChanges();

        return _mapper.Map<ReadCategoryDto>(category);
    }

    public bool RemoveById(int id)
    {
        var category = _repository.GetById(id);

        if (category == null) return false;
        
        _repository.Remove(category);
        _repository.SaveChanges();

        return true;
    }
}