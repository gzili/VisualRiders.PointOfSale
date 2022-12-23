using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Profiles;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class ProductsService
{
    private readonly CategoriesRepository _categoriesRepository;
    private readonly TaxesRepository _taxesRepository;
    private readonly ProductsRepository _repository;
    private readonly IMapper _mapper;

    public ProductsService(ProductsRepository repository, CategoriesRepository categoriesRepository, TaxesRepository taxesRepository, IMapper mapper)
    {
        _repository = repository;
        _categoriesRepository = categoriesRepository;
        _taxesRepository = taxesRepository;
        _mapper = mapper;
    }

    public ReadProductDto Create(CreateUpdateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);

        product.BusinessEntityId = 1;

        if (dto.TaxId is not null)
        {
            var tax = _taxesRepository.GetById(dto.TaxId.Value);
            if (tax is null)
            {
                throw new ArgumentException("Invalid tax id. Tax with provided id does not exist.");
            }

            product.Tax = tax;
        }

        var category = _categoriesRepository.GetById(dto.CategoryId);
        if (category is null)
        {
            throw new ArgumentException("Invalid category id. Category with provided id does not exist.");
        }

        product.Category = category;

        _repository.Add(product);
        _repository.SaveChanges();

        return _mapper.Map<ReadProductDto>(product);
    }

    public List<ReadProductDto> GetAll()
    {
        return _repository.GetAll().Select(category => _mapper.Map<ReadProductDto>(category)).ToList();
    }

    public ReadProductDto? GetById(int id)
    {
        return _mapper.Map<ReadProductDto>(_repository.GetById(id));
    }

    public ReadProductDto? UpdateById(int id, CreateUpdateProductDto dto)
    {
        var product = _repository.GetById(id);

        if (product == null) return null;

        product.Name = dto.Name;
        product.TaxId = dto.TaxId;
        
        if (dto.TaxId is not null)
        {
            var tax = _taxesRepository.GetById(dto.TaxId.Value);
            if (tax is null)
            {
                throw new ArgumentException("Invalid tax id. Tax with provided id does not exist.");
            }

            product.Tax = tax;
        }
        else
        {
            product.Tax = null;
        }
        
        var category = _categoriesRepository.GetById(dto.CategoryId);
        if (category is null)
        {
            throw new ArgumentException("Invalid category id. Category with provided id does not exist.");
        }

        product.Category = category;
        
        _repository.SaveChanges();

        return _mapper.Map<ReadProductDto>(product);
    }

    public bool RemoveById(int id)
    {
        var product = _repository.GetById(id);

        if (product == null) return false;
        
        _repository.Remove(product);
        _repository.SaveChanges();

        return true;
    }
}