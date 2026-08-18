using ECommerce.Application.DTOs.Product;
using ECommerce.Application.UseCases.Products.Commands.Create;
using ECommerce.Application.UseCases.Products.Commands.Delete;
using ECommerce.Application.UseCases.Products.Commands.Update;
using ECommerce.Application.UseCases.Products.Queries.GetById;
using ECommerce.Application.UseCases.Products.Queries.GetPaged;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailsDto>> GetById(int id)
    {
        var product = await _sender.Send(new GetProductByIdQuery { Id = id});
        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<ProductDetailsDto>> GetPaged([FromQuery] GetPagedProductsQuery query)
    {
        var products = await _sender.Send(query);
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateProductCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _sender.Send(new DeleteProductCommand { Id = id});
        return Ok();
    }
}
