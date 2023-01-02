using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("clients")]
public class ClientsController : ControllerBase
{
    private readonly ClientsService _service;
    private readonly ClientLoyaltiesService _clientLoyaltiesService;

    public ClientsController(ClientsService service, ClientLoyaltiesService clientLoyaltySerive)
    {
        _service = service;
        _clientLoyaltiesService = clientLoyaltySerive;
    }

    [HttpGet]
    public List<ReadClientDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost]
    public ActionResult<ReadClientDto> Create(CreateUpdateClientDto payload)
    {
        return _service.Create(payload);
    }

    [HttpGet("{id:int}")]
    public ActionResult<ReadClientDto> GetById(int id)
    {
        var client = _service.GetById(id);

        if (client == null) return NotFound();

        return client;
    }

    [HttpPut("{id:int}")]
    public ActionResult<ReadClientDto> Update(int id, CreateUpdateClientDto payload)
    {
        var client = _service.UpdateById(id, payload);

        if (client == null) return NotFound();

        return client;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ok = _service.RemoveById(id);

        if (!ok) return NotFound();

        return NoContent();
    }

    [HttpGet("{id:int}/loyalty")]
    public ActionResult<ClientLoyalty> GetLoyalty(int id)
    {
        var client = _service.GetById(id);

        if (client == null) return NotFound();

        if (client.ClientLoyaltyId.HasValue)
        {
            return _clientLoyaltiesService.GetById(client.ClientLoyaltyId.Value)!;
        }

        return NoContent();
    }
}