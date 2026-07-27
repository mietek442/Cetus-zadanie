
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Features.Desks.Queries.GetAllDesks
{
    public class GetAllDeskEndpoint : EndpointBaseAsync
        .WithoutRequest
        .WithResult<ActionResult<List<DeskResult>>>
    {
        private readonly IMediator _mediator;

        public GetAllDeskEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/desks")]
        [SwaggerOperation(
            Summary = "Get All Desks",
            Description = "Retrieve all desks from the database",
            OperationId = "Desks_GetAll",
            Tags = new[] { "Desks" })
        ]
        public override async Task<ActionResult<List<DeskResult>>> HandleAsync(
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetDesksQuery());
        }
    }
}