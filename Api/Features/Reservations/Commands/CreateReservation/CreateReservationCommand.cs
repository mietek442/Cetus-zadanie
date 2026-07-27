namespace Api.Features.Reservations.Commands.CreateReservation
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Api.Domain.Models;
    using Api.Infrastructure.DbContext;
    using Api.Shared.Enums;

    public class CreateReservationCommand : IRequest<ActionResult<CreateReservationResult>>
    {
        public CreateReservationRequest ReservationRequest { get; set; } = null!;
    }

    public class CreateReservationCommandHandler
        : IRequestHandler<CreateReservationCommand, ActionResult<CreateReservationResult>>
    {
        private readonly IApplicationContext _context;

        public CreateReservationCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<CreateReservationResult>> Handle(
            CreateReservationCommand request,
            CancellationToken cancellationToken)
        {
            var desk = await _context.Desks
                .FirstAsync(
                    d => d.Id == request.ReservationRequest.DeskId,
                    cancellationToken);

            var reservation = new Reservation
            {
                DeskId = desk.Id,
                Desk = desk,
                StartDateTime = request.ReservationRequest.StartDateTime,
                EndDateTime = request.ReservationRequest.EndDateTime,
                Status = ReservationStatusEnum.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Reservations.AddAsync(reservation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var result = new CreateReservationResult
            {
                Id = reservation.Id,
                DeskId = reservation.DeskId,
                StartDateTime = reservation.StartDateTime,
                EndDateTime = reservation.EndDateTime,
                Status = reservation.Status,
                CreatedAt = reservation.CreatedAt,
                Desk = desk
            };

            return new OkObjectResult(result);
        }
    }
}