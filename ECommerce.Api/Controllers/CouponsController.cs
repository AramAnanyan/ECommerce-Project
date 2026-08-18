using ECommerce.Application.DTOs.Coupon;
using ECommerce.Application.UseCases.Coupons.Commands.Create;
using ECommerce.Application.UseCases.Coupons.Commands.Delete;
using ECommerce.Application.UseCases.Coupons.Commands.Update;
using ECommerce.Application.UseCases.Coupons.Queries.GetById;
using ECommerce.Application.UseCases.Coupons.Queries.GetPaged;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponsController : ControllerBase
{
    private readonly ISender _sender;

    public CouponsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CouponDto>> GetById(int id)
    {
        var coupon = await _sender.Send(new GetCouponByIdQuery { Id=id});
        return Ok(coupon);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<CouponDto>>> GetPaged([FromQuery] GetPagedCouponsQuery query)
    {
        var coupons = await _sender.Send(query);
        return Ok(coupons);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCouponCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateCouponCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _sender.Send(new DeleteCouponCommand { Id = id });
        return Ok();
    }
}
