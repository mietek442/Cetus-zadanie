using Api.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Reservations.Commands.ChangeReservationStatus
{
    public class ChangeStatusReservationRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }


        [FromQuery]
        public ReservationStatusEnum Status { get; set; }
    }
}
