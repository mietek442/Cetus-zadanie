using Api.Features.Reservations.Commands.ChangeReservationStatus;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Features.Reservations.Commands.ChangeStatusReservation
{
    public class ChangeStatusReservationEndpoint : EndpointBaseAsync
        .WithRequest<ChangeStatusReservationRequest>
        .WithActionResult<bool>
    {
        private readonly IMediator _mediator;

        public ChangeStatusReservationEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPut("api/reservations/{id}/status")]
        [SwaggerOperation(
            Summary = "Changes reservation status",
            Description = "Changes reservation status by ID",
            OperationId = "Reservations_ChangeStatus",
            Tags = new[] { "Reservations" })
        ]
        public override async Task<ActionResult<bool>> HandleAsync(
            ChangeStatusReservationRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(
                new ChangeStatusReservationCommand
                {
                    ReservationId = request.Id,
                    Status = request.Status
                },
                cancellationToken);
        }
    }
}