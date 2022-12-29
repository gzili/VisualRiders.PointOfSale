using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("loyalties")]
public class LoyaltiesController : ControllerBase
{
    private readonly LoyaltiesService _service;

    public LoyaltiesController(LoyaltiesService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<ReadLoyaltyDto> Create (CreateUpdateLoyaltyDto payload)
    {
        return _service.Create(payload);
    }

    [HttpGet]
    public List<ReadLoyaltyDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadLoyaltyDto> GetById(int id)
    {
        var loyalty = _service.GetById(id);

        if (loyalty == null) return NotFound();

        return loyalty;
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<ReadLoyaltyDto> Update(int id, CreateUpdateLoyaltyDto payload)
    {
        var loyalty = _service.UpdateById(id, payload);

        if (loyalty == null) return NotFound();

        return loyalty;
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var ok = _service.RemoveById(id);

        if (!ok) return NotFound();

        return NoContent();
    }
}