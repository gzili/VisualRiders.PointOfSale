using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("discounts")]
public class DiscountsController : ControllerBase
{
    private readonly DiscountsService _service;
    private readonly DiscountItemsService _discountItemsService;

    public DiscountsController(DiscountsService service, DiscountItemsService discountItemsService)
    {
        _service = service;
        _discountItemsService = discountItemsService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public Discount Create(CreateUpdateDiscountDto payload)
    {
        return _service.Create(payload);
    }

    [HttpGet]
    public List<ReadDiscountDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{discountId:int}/items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<ReadDiscountItemDto>> GetItems(int id)
    {
        if (_service.GetById(id) == null) return NotFound();

        var discountItems = _discountItemsService.GetByDiscountId(id);

        if (discountItems == null) return NoContent();

        return discountItems;
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadDiscountDto> GetById(int id)
    {
        var discount  = _service.GetById(id);

        if (discount == null) return NotFound();

        return discount;
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadDiscountDto> Update(int id, CreateUpdateDiscountDto payload)
    {
        var discount = _service.UpdateById(id, payload);

        if (discount == null) return NotFound();

        return discount;
    }

    [HttpPost("{discountId:int}/items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadDiscountItemDto> AddItem(int discountId, CreateUpdateDiscountItemDto payload)
    {
        var discountItem = _service.AddItemById(discountId, payload);

        if (discountItem == null) return NotFound();

        return discountItem;
    }

    [HttpPut("{discountId:int}/items/{itemId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadDiscountItemDto> UpdateItem(int discountId, int itemId, CreateUpdateDiscountItemDto payload)
    {
        var discountItem = _service.UpdateItemById(discountId, itemId, payload);

        if (discountItem == null) return NotFound();

        return discountItem;
    }

    [HttpDelete("{discountId:int}/items/{itemId:int}")]
    public IActionResult DeleteItem(int discountId, int itemId)
    {
        var ok = _service.RemoveItemById(discountId, itemId);

        if (!ok) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var ok = _service.RemoveById(id);

        if(!ok) return NotFound();

        return NoContent();
    }
}