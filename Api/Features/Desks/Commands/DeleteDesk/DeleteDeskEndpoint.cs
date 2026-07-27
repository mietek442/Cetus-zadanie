using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Features.Desks.Commands.DeleteDesk
{
    public class DeleteDeskEndpoint : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult
    {
        private readonly IMediator _mediator;

        public DeleteDeskEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("api/desks/{id}")]
        [SwaggerOperation(
            Summary = "Deletes a Desk",
            Description = "Deletes a Desk by ID",
            OperationId = "Desks_Delete",
            Tags = new[] { "Desks" })
        ]
        public override async Task<ActionResult> HandleAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new DeleteDeskCommand
            {
                DeskId = id
            });
        }
    }
}