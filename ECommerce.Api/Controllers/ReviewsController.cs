using ECommerce.Application.DTOs.Review;
using ECommerce.Application.UseCases.Reviews.Commands.Create;
using ECommerce.Application.UseCases.Reviews.Commands.Delete;
using ECommerce.Application.UseCases.Reviews.Commands.Update;
using ECommerce.Application.UseCases.Reviews.Queries.GetByProductId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly ISender _sender;

    public ReviewsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<List<ReviewDto>>> GetByProductId(int productId)
    {
        var reviews = await _sender.Send(new GetProductReviewsQuery { ProductId = productId });
        return Ok(reviews);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateReviewCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateReviewCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _sender.Send(new DeleteReviewCommand { Id = id});
        return Ok();
    }
}
