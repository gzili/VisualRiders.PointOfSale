using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("shifts")]
public class ShiftsController : ControllerBase
{
    private readonly ShiftsService _service;

    public ShiftsController(ShiftsService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<ReadShiftDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost]
    public ActionResult<ReadShiftDto> Create(CreateUpdateShiftDto payload)
    {
        return _service.Create(payload);
    }

    [HttpGet("{id:int}")]
    public ActionResult<ReadShiftDto> GetById(int id)
    {
        var shift = _service.GetById(id);

        if (shift == null) return NotFound();

        return shift;
    }

    [HttpPut("{id:int}")]
    public ActionResult<ReadShiftDto> Update(int id, CreateUpdateShiftDto payload)
    {
        var shift = _service.UpdateById(id, payload);

        if (shift == null) return NotFound();

        return shift;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ok = _service.RemoveById(id);

        if (!ok) return NotFound();

        return NoContent();
    }
}