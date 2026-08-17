using ECommerce.Application.DTOs.Customer;
using ECommerce.Application.UseCases.Customers.Commands.Create;
using ECommerce.Application.UseCases.Customers.Commands.Delete;
using ECommerce.Application.UseCases.Customers.Commands.Update;
using ECommerce.Application.UseCases.Customers.Queries.GetById;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ISender _sender;
    public CustomersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDetailsDto>> GetById(int id)
    {
        var customer = await _sender.Send(new GetCustomerByIdQuery { Id = id });
        return Ok(customer);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<CustomerDetailsDto>>> GetPaged(int id)
    {
        var customer = await _sender.Send(new GetCustomerByIdQuery { Id = id });
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _sender.Send(new DeleteCustomerCommand{Id = id});
        return Ok();
    }
}
