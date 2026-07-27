using Api.Domain.Models;
using Api.Shared.Enums;

namespace Api.Features.Reservations.Commands.CreateReservation
{
    public class CreateReservationResult
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid DeskId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public ReservationStatusEnum Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public Desk Desk { get; set; } = null!;
    }

}
