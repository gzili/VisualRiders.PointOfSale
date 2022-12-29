using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("clientLoyalties")]
public class ClientLoyaltiesController : ControllerBase
{
    private readonly ClientLoyaltiesService _service;

    public ClientLoyaltiesController(ClientLoyaltiesService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<ClientLoyalty> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost]
    public ActionResult<ClientLoyalty> Create(CreateUpdateClientLoyaltyDto payload)
    {
        return _service.Create(payload);
    }

    [HttpGet("{id:int}")]
    public ActionResult<ClientLoyalty> GetById(int id)
    {
        var cLoyalty = _service.GetById(id);

        if (cLoyalty == null) return NotFound();

        return cLoyalty;
    }

    [HttpPut("{id:int}")]
    public ActionResult<ClientLoyalty> Update(int id, CreateUpdateClientLoyaltyDto payload)
    {
        var cLoyalty = _service.UpdateById(id, payload);

        if (cLoyalty == null) return NotFound();

        return cLoyalty;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ok = _service.RemoveById(id);

        if (!ok) return NotFound();

        return NoContent();
    }
}