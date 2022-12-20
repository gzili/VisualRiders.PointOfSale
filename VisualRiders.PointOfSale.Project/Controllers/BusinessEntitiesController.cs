using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("businessEntities")]
public class BusinessEntitiesController : ControllerBase
{
    private readonly BusinessEntitiesService _service;

    public BusinessEntitiesController(BusinessEntitiesService service)
    {
        _service = service;
    }

    [HttpPost]
    public BusinessEntity Create(CreateUpdateBusinessEntityDto payload)
    {
        return _service.Create(payload);
    }

    [HttpGet]
    public List<BusinessEntity> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id:int}")]
    public ActionResult<BusinessEntity> GetById(int id)
    {
        var businessEntity = _service.GetById(id);

        if (businessEntity == null) return NotFound();

        return businessEntity;
    }

    [HttpPut("{id:int}")]
    public ActionResult<BusinessEntity> Update(int id, CreateUpdateBusinessEntityDto payload)
    {
        var businessEntity = _service.UpdateById(id, payload);

        if (businessEntity == null) return NotFound();

        return businessEntity;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ok = _service.RemoveById(id);

        if (!ok) return NotFound();

        return NoContent();
    }
}