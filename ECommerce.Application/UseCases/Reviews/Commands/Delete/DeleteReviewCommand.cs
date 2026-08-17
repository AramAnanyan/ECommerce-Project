using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Reviews.Commands.Delete;

public sealed record DeleteReviewCommand:IRequest
{
    public int Id { get; init; }
}
