using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("staff")]
public class StaffMembersController : ControllerBase
{
    private readonly StaffMembersService _service;

    public StaffMembersController(StaffMembersService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<ReadStaffMemberDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost]
    public ActionResult<ReadStaffMemberDto> Create(CreateUpdateStaffMemberDto payload)
    {
        return _service.Create(payload);
    }

    [HttpGet("{id:int}")]
    public ActionResult<ReadStaffMemberDto> GetById(int id)
    {
        var staffMember = _service.GetById(id);

        if (staffMember == null) return NotFound();

        return staffMember;
    }

    [HttpPut("{id:int}")]
    public ActionResult<ReadStaffMemberDto> Update(int id, CreateUpdateStaffMemberDto payload)
    {
        var staffMember = _service.UpdateById(id, payload);

        if (staffMember == null) return NotFound();

        return staffMember;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ok = _service.RemoveById(id);

        if (!ok) return NotFound();

        return NoContent();
    }
}