using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly OrdersService _ordersService;

    public OrdersController(OrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<ReadOrderDto> Create(CreateOrderDto payload)
    {
        var order = _ordersService.Create(payload);

        return CreatedAtAction("GetById", new { id = order.Id }, order);
    }

    [HttpGet]
    public List<ReadOrderListDto> GetAll()
    {
        return _ordersService.GetAll();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadOrderDto> GetById(int id)
    {
        var order = _ordersService.GetById(id);

        if (order == null) return NotFound();

        return order;
    }

    [HttpPut("{id:int}/status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadOrderDto> UpdateStatus(int id, UpdateOrderStatusDto payload)
    {
        var order = _ordersService.UpdateStatus(id, payload);

        if (order == null) return NotFound();

        return order;
    }
    
    [HttpPut("{id:int}/tips")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadOrderDto> UpdateTips(int id, UpdateOrderTipsDto payload)
    {
        var order = _ordersService.UpdateTips(id, payload);

        if (order == null) return NotFound();

        return order;
    }

    [HttpPost("{orderId:int}/items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<ReadOrderDto> AddItem(int orderId, CreateOrderItemDto payload)
    {
        var order = _ordersService.AddItem(orderId, payload);

        if (order == null) return NotFound();

        return order;
    }
    
    [HttpPost("{orderId:int}/items/{itemId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<ReadOrderDto> UpdateItem(int orderId, int itemId, UpdateOrderItemDto payload)
    {
        var order = _ordersService.UpdateItem(orderId, itemId, payload);

        if (order == null) return NotFound();

        return order;
    }

    [HttpDelete("{orderId:int}/items/{itemId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadOrderDto> RemoveItem(int orderId, int itemId)
    {
        var order = _ordersService.DeleteItem(orderId, itemId);

        if (order == null) return NotFound();

        return order;
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var ok = _ordersService.Delete(id);

        if (!ok) return NotFound();

        return NoContent();
    }
}