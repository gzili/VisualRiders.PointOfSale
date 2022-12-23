using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("categories")]
public class CategoriesController : ControllerBase
{
    private readonly CategoriesService _service;

    public CategoriesController(CategoriesService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ReadCategoryDto> Create(CreateUpdateCategoryDto payload)
    {
        try
        {
            return _service.Create(payload);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public List<ReadCategoryDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadCategoryDto> GetById(int id)
    {
        var category = _service.GetById(id);

        if (category == null) return NotFound();

        return category;
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ReadCategoryDto> Update(int id, CreateUpdateCategoryDto payload)
    {
        try
        {
            var category = _service.UpdateById(id, payload);

            if (category == null) return NotFound();

            return category;
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
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