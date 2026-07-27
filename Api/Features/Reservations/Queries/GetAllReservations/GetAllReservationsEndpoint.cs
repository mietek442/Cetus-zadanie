using Api.Domain.Models;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Features.Reservations.Queries.GetAllReservations
{
    public class GetAllReservationsEndpoint : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<List<Reservation>>
    {
        private readonly IMediator _mediator;

        public GetAllReservationsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/reservations")]
        [SwaggerOperation(
            Summary = "Gets all Reservations",
            Description = "Retrieves a list of all reservations",
            OperationId = "Reservations_GetAll",
            Tags = new[] { "Reservations" })
        ]
        public override async Task<ActionResult<List<Reservation>>> HandleAsync(
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(
                new GetAllReservationsQuery(),
                cancellationToken);
        }
    }
}