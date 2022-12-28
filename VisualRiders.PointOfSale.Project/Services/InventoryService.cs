using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class InventoryService
{
    private readonly InventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public InventoryService(InventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }

    public ReadInventoryDto? GetByProductId(int productId)
    {
        var inventory = _inventoryRepository.GetByProductId(productId);

        return _mapper.Map<ReadInventoryDto>(inventory);
    }

    public ReadInventoryDto Update(int productId, UpdateInventoryDto dto)
    {
        var inventory = _inventoryRepository.GetByProductId(productId);

        if (inventory != null)
        {
            _mapper.Map(dto, inventory);
        }
        else
        {
            inventory = _mapper.Map<Inventory>(dto);
            inventory.BusinessEntityId = 1;
            inventory.ProductId = productId;
            _inventoryRepository.Add(inventory);
        }
        
        _inventoryRepository.SaveChanges();

        return _mapper.Map<ReadInventoryDto>(inventory);
    }
}