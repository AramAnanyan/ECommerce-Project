using ECommerce.Application.DTOs.Payment;
using ECommerce.Application.UseCases.Orders.Queries.GetPaged;
using ECommerce.Application.UseCases.Payments.Commands.Create;
using ECommerce.Application.UseCases.Payments.Commands.Delete;
using ECommerce.Application.UseCases.Payments.Commands.Update;
using ECommerce.Application.UseCases.Payments.Queries.GetById;
using ECommerce.Application.UseCases.Payments.Queries.GetPaged;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly ISender _sender;
    public PaymentsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentDto>> GetById(int id)
    {
        var payment = await _sender.Send(new GetPaymentByIdQuery{Id = id});
        return Ok(payment);
    }

    [HttpGet]
    public async Task<ActionResult<PaymentDto>> GetPaged([FromQuery] GetPagedPaymentsQuery query)
    {
        var payments = await _sender.Send(query);
        return Ok(payments);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePaymentCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdatePaymentCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _sender.Send(new DeletePaymentCommand { Id=id});
        return Ok();
    }
}
