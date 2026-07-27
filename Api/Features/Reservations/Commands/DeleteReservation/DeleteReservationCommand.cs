namespace Api.Features.Reservations.Commands.DeleteReservation
{
    using Api.Infrastructure.DbContext;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class DeleteReservationCommand : IRequest<ActionResult<Guid>>
    {
        public Guid ReservationId;
    }

    public class DeleteReservationCommandHandler
        : IRequestHandler<DeleteReservationCommand, ActionResult<Guid>>
    {
        private readonly IApplicationContext _context;

        public DeleteReservationCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Guid>> Handle(
            DeleteReservationCommand request,
            CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservations
                .FindAsync(request.ReservationId, cancellationToken);

            if (reservation == null)
            {
                return new NotFoundResult();
            }

            _context.Reservations.Remove(reservation);

            await _context.SaveChangesAsync(cancellationToken);

            return new OkObjectResult(request.ReservationId);
        }
    }
}