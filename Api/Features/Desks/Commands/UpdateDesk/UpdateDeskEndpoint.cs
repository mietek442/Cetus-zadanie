using Api.Domain.Models;
using Api.Features.Desks.Queries.GetByIdDesk;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Features.Desks.Commands.UpdateDesk
{
    public class UpdateDeskEndpoint : EndpointBaseAsync
        .WithRequest<UpdateDeskRequest>
        .WithActionResult<Desk>
    {
        private readonly IMediator _mediator;

        public UpdateDeskEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("api/desks/{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing Desk",
            Description = "Updates an existing Desk by ID",
            OperationId = "Desks_Update",
            Tags = new[] { "Desks" })
        ]
        public override async Task<ActionResult<Desk>> HandleAsync(
            UpdateDeskRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new UpdateDeskCommand
            {
                Id = request.Id,
                Desk = request.Desk
            });
        }
    }
}