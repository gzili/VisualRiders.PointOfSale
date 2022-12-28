using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Profiles;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;
    private readonly InventoryService _inventoryService;

    public ProductsController(ProductsService productsService, InventoryService inventoryService)
    {
        _productsService = productsService;
        _inventoryService = inventoryService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ReadProductDto> Create(CreateUpdateProductDto payload)
    {
        return _productsService.Create(payload);
    }

    [HttpGet]
    public List<ReadProductDto> GetAll()
    {
        return _productsService.GetAll();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadProductDto> GetById(int id)
    {
        var category = _productsService.GetById(id);

        if (category == null) return NotFound();

        return category;
    }
    
    [HttpGet("{id:int}/inventory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadInventoryDto> GetInventory(int id)
    {
        if (_productsService.GetById(id) == null) return NotFound();
        
        var inventory = _inventoryService.GetByProductId(id);

        if (inventory == null) return NoContent();

        return inventory;
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadProductDto> Update(int id, CreateUpdateProductDto payload)
    {
        var category = _productsService.UpdateById(id, payload);

        if (category == null) return NotFound();

        return category;
    }

    [HttpPut("{id:int}/inventory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadInventoryDto> UpdateInventory(int id, UpdateInventoryDto payload)
    {
        if (_productsService.GetById(id) == null) return NotFound();
        
        return _inventoryService.Update(id, payload);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var ok = _productsService.RemoveById(id);

        if (!ok) return NotFound();

        return NoContent();
    }
}