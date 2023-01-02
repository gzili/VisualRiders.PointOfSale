using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Services;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("payments")]
public class PaymentsController : ControllerBase
{
    private readonly PaymentsService _paymentsService;

    public PaymentsController(PaymentsService paymentsService)
    {
        _paymentsService = paymentsService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public ReadPaymentDto Create(CreatePaymentDto payload)
    {
        return _paymentsService.Create(payload);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public List<ReadPaymentDto> GetAll(int? orderId)
    {
        return _paymentsService.GetAll(orderId);
    }
}