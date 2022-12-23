using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class InventoriesService
{
    private readonly InventoriesRepository _repository;
    private readonly ProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public InventoriesService(InventoriesRepository repository, ProductsRepository taxesRepository, IMapper mapper)
    {
        _repository = repository;
        _productsRepository = taxesRepository;
        _mapper = mapper;
    }

    public ReadInventoryDto Create(CreateInventoryDto dto)
    {
        var inventory = _mapper.Map<Inventory>(dto);

        inventory.BusinessEntityId = 1;
        inventory.LastRefill = DateTime.Now;
        
        var product = _productsRepository.GetById(dto.ProductId);
        if (product is null)
        {
            throw new ArgumentException("Invalid product id. Product with provided id does not exist.");
        }

        if (_repository.GetAll().Find(inv => inv.ProductId.Equals(dto.ProductId)) is not null)
        {
            throw new ArgumentException("Inventory entry with provided product id already exists");
        }

        inventory.Product = product;

        _repository.Add(inventory);
        _repository.SaveChanges();

        return _mapper.Map<ReadInventoryDto>(inventory);
    }

    public List<ReadInventoryDto> GetAll()
    {
        return _repository.GetAll().Select(category => _mapper.Map<ReadInventoryDto>(category)).ToList();
    }

    public ReadInventoryDto? GetById(int id)
    {
        return _mapper.Map<ReadInventoryDto>(_repository.GetById(id));
    }

    public ReadInventoryDto? UpdateById(int id, UpdateInventoryDto dto)
    {
        var inventory = _repository.GetById(id);

        if (inventory == null) return null;
        
        inventory.LastRefill = DateTime.Now;
        inventory.Quantity = dto.Quantity;

        _repository.SaveChanges();

        return _mapper.Map<ReadInventoryDto>(inventory);
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