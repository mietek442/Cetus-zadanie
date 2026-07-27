namespace Api.Features.Reservations.Commands.CreateReservation
{
    using Ardalis.ApiEndpoints;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    public class CreateReservationEndpoint : EndpointBaseAsync
        .WithRequest<CreateReservationRequest>
        .WithActionResult<CreateReservationResult>
    {
        private readonly IMediator _mediator;

        public CreateReservationEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/reservations")]
        [SwaggerOperation(
            Summary = "Creates a new Reservation",
            Description = "Creates a new Reservation",
            OperationId = "Reservations_Create",
            Tags = new[] { "Reservations" })
        ]
        public override async Task<ActionResult<CreateReservationResult>> HandleAsync(
            CreateReservationRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(
                new CreateReservationCommand
                {
                    ReservationRequest = request
                },
                cancellationToken);
        }
    }
}