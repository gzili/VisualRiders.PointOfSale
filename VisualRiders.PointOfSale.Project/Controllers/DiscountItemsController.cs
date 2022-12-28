using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("discountItems")]
public class DiscountItemsController : ControllerBase
{
    private readonly DiscountItemsService _service;

    public DiscountItemsController(DiscountItemsService service)
    {
        _service = service;
    }

    //[HttpPost]
    //public DiscountItem Create(CreateUpdateDiscountItemDto payload)
    //{
    //    return _service.Create(payload);
    //}

    [HttpGet]
    public List<DiscountItem> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id:int}")]
    public ActionResult<DiscountItem> GetById(int id)
    {
        var discountItem = _service.GetById(id);

        if(discountItem == null) return NotFound();

        return discountItem;
    }

    //[HttpDelete("{id:int}")]
    //public IActionResult Delete(int id)
    //{
    //    var ok = _service.RemoveById(id);

    //    if (!ok) return NotFound();

    //    return NoContent();
    //}
}