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
    public List<StaffMember> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost]
    public ActionResult<StaffMember> Create(CreateUpdateStaffMemberDto payload)
    {
        try
        {
            return _service.Create(payload);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.StackTrace);
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<StaffMember> GetById(int id)
    {
        var StaffMember = _service.GetById(id);

        if (StaffMember == null) return NotFound();

        return StaffMember;
    }

    [HttpPut("{id:int}")]
    public ActionResult<StaffMember> Update(int id, CreateUpdateStaffMemberDto payload)
    {
        var StaffMember = _service.UpdateById(id, payload);

        if (StaffMember == null) return NotFound();

        return StaffMember;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ok = _service.RemoveById(id);

        if (!ok) return NotFound();

        return NoContent();
    }
}