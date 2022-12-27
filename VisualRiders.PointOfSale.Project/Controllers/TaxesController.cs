using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("taxes")]
public class TaxesController : ControllerBase
{
    private readonly TaxesService _service;

    public TaxesController(TaxesService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ReadTaxDto Create(CreateUpdateTaxDto payload)
    {
        return _service.Create(payload);
    }
    
    [HttpGet]
    public List<ReadTaxDto> GetAll()
    {
        return _service.GetAll();
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadTaxDto> GetById(int id)
    {
        var tax = _service.GetById(id);

        if (tax == null) return NotFound();

        return tax;
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadTaxDto> Update(int id, CreateUpdateTaxDto payload)
    {
        var tax = _service.UpdateById(id, payload);

        if (tax == null) return NotFound();

        return tax;
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