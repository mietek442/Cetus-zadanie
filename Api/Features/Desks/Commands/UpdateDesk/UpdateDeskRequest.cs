using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Desks.Commands.UpdateDesk
{
    public class UpdateDeskRequest
    {
        [FromRoute(Name = "id")] public Guid Id { get; set; }
        [FromBody] public required Desk Desk { get; set; }
    }
}
