namespace Api.Features.Reservations.Commands.DeleteReservation
{
    using Ardalis.ApiEndpoints;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    public class DeleteReservationEndpoint : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<Guid>
    {
        private readonly IMediator _mediator;

        public DeleteReservationEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}/api/reservations/")]
        [SwaggerOperation(
            Summary = "Delete reservation",
            Description = "Delete Reservation by ID",
            OperationId = "Reservations_Delete",
            Tags = new[] { "Reservations" })
        ]
        public override async Task<ActionResult<Guid>> HandleAsync(
            [FromRoute(Name = "id")] Guid request,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(
                new DeleteReservationCommand
                {
                    ReservationId = request
                },
                cancellationToken);
        }
    }
}