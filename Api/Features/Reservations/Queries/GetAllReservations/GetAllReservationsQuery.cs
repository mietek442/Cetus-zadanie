using Api.Domain.Models;
using Api.Infrastructure.DbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Reservations.Queries.GetAllReservations
{
    public class GetAllReservationsQuery : IRequest<ActionResult<List<Reservation>>>
    {
    }

    public class GetAllReservationsQueryHandler
        : IRequestHandler<GetAllReservationsQuery, ActionResult<List<Reservation>>>
    {
        private readonly IApplicationContext _context;

        public GetAllReservationsQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Reservation>>> Handle(
            GetAllReservationsQuery request,
            CancellationToken cancellationToken)
        {
            var reservations = await _context.Reservations
                .Include(reservation => reservation.Desk)
                .ToListAsync(cancellationToken);


            if (reservations == null || reservations.Count == 0)
            {
                return new NotFoundResult();
            }


            return new OkObjectResult(reservations);
        }
    }
}