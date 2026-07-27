using Api.Infrastructure.DbContext;
using Api.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Reservations.Commands.ChangeReservationStatus
{
    public class ChangeStatusReservationCommand : IRequest<ActionResult<bool>>
    {
        public Guid ReservationId { get; set; }

        public ReservationStatusEnum Status { get; set; }
    }


    public class ChangeStatusReservationCommandHandler
        : IRequestHandler<ChangeStatusReservationCommand, ActionResult<bool>>
    {
        private readonly IApplicationContext _context;

        public ChangeStatusReservationCommandHandler(IApplicationContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<bool>> Handle(
            ChangeStatusReservationCommand request,
            CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(
                    r => r.Id == request.ReservationId,
                    cancellationToken);


            if (reservation == null)
            {
                return new NotFoundObjectResult(new
                {
                    Message = "Reservation not found."
                });
            }


         
            reservation.Status = request.Status;
            reservation.UpdatedAt = DateTime.UtcNow;


            await _context.SaveChangesAsync(cancellationToken);


            return new OkObjectResult(true);
        }
    }
}