using Api.Domain.Models;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Features.Desks.Queries.GetByIdDesk
{
    public class GetByIdDeskEndpoint : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<Desk>
    {
        private readonly IMediator _mediator;

        public GetByIdDeskEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/desks/{id}")]
        [SwaggerOperation(
            Summary = "Get Desk by Id",
            Description = "Retrieve desk by its identifier",
            OperationId = "Desks_GetById",
            Tags = new[] { "Desks" })
        ]
        public override async Task<ActionResult<Desk>> HandleAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(
                new GetDeskByIdQuery
                {
                    Id = id
                },
                cancellationToken);
        }
    }
}