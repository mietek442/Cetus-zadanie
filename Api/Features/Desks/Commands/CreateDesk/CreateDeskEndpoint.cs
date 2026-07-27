using Api.Domain.Models;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Features.Desks.Commands.CreateDesk
{
    public class CreateDeskEndpoint : EndpointBaseAsync
        .WithRequest<CreateDeskRequest>
        .WithActionResult<Desk>
    {
        private readonly IMediator _mediator;

        public CreateDeskEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/desks")]
        [SwaggerOperation(
            Summary = "Creates a new Desk",
            Description = "Creates a new Desk",
            OperationId = "Desks_Create",
            Tags = new[] { "Desks" })
        ]
        public override async Task<ActionResult<Desk>> HandleAsync(
            CreateDeskRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new CreateDeskCommand
            {
                DeskRequest = request
            });
        }
    }
}