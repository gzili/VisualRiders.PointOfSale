using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
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
        if (product == null)
        {
            throw new UnprocessableEntity($"Product with Id = {dto.ProductId} does not exist");
        }

        if (!_repository.GetAll().Any(inv => inv.ProductId.Equals(dto.ProductId)))
        {
            throw new UnprocessableEntity($"Inventory entry with product Id = {dto.ProductId} already exists");
        }

        inventory.Product = product;

        _repository.Add(inventory);
        _repository.SaveChanges();

        return _mapper.Map<ReadInventoryDto>(inventory);
    }

    public List<ReadInventoryDto> GetAll()
    {
        return _repository.GetAll().Select(_mapper.Map<ReadInventoryDto>).ToList();
    }

    public ReadInventoryDto? GetById(int id)
    {
        return _mapper.Map<ReadInventoryDto>(_repository.GetById(id));
    }

    public ReadInventoryDto? UpdateById(int id, UpdateInventoryDto dto)
    {
        var inventory = _repository.GetById(id);

        if (inventory == null) return null;
        
        _mapper.Map(dto, inventory);
        
        inventory.LastRefill = DateTime.Now;

        _repository.SaveChanges();

        return _mapper.Map<ReadInventoryDto>(inventory);
    }

    public bool RemoveById(int id)
    {
        var inventory = _repository.GetById(id);

        if (inventory == null) return false;
        
        _repository.Remove(inventory);
        _repository.SaveChanges();

        return true;
    }
}