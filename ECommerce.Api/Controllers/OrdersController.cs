using ECommerce.Application.DTOs.Order;
using ECommerce.Application.UseCases.Orders.Commands.Create;
using ECommerce.Application.UseCases.Orders.Commands.Delete;
using ECommerce.Application.UseCases.Orders.Commands.Update;
using ECommerce.Application.UseCases.Orders.Queries.GetById;
using ECommerce.Application.UseCases.Orders.Queries.GetPaged;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;
    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetailsDto>> GetById(int id)
    {
        var order = await _sender.Send(new GetOrderByIdQuery{Id = id});
        return Ok(order);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<OrderDetailsDto>>> GetPaged(GetPagedOrdersQuery query)
    {
        var orders = await _sender.Send(query);
        return Ok(orders);
    }


    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateOrderCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateOrderCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _sender.Send(new DeleteOrderCommand{Id=id});
        return Ok();
    }
}
