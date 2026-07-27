namespace Api.Features.Reservations.Commands.CreateReservation
{
    public class CreateReservationRequest
    {
        public Guid UserId { get; set; }

        public Guid DeskId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
