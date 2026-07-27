using Api.Domain.Models;
using Api.Infrastructure.DbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Desks.Commands.UpdateDesk
{
    public class UpdateDeskCommand : IRequest<ActionResult<Desk>>
    {
        public Guid Id { get; set; }
        public required Desk Desk { get; set; }
    }

    public class UpdateDeskCommandHandler : IRequestHandler<UpdateDeskCommand, ActionResult<Desk>>
    {
        private readonly IApplicationContext _context;

        public UpdateDeskCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Desk>> Handle(
            UpdateDeskCommand request,
            CancellationToken cancellationToken)
        {
            var desk = await _context.Desks
                .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (desk == null)
            {
                return new NotFoundResult();
            }

            
            desk.Name = request.Desk.Name;
            desk.Description = request.Desk.Description;
            desk.IsAvailable = request.Desk.IsAvailable;
            desk.PricePerHour = request.Desk.PricePerHour;
            desk.ChairType = request.Desk.ChairType;
            desk.HasMouse = request.Desk.HasMouse;
            desk.HasHeadphones = request.Desk.HasHeadphones;
            desk.HasWebcam = request.Desk.HasWebcam;
            desk.HasLamp = request.Desk.HasLamp;
            desk.HasEthernet = request.Desk.HasEthernet;
            desk.HasUsbHub = request.Desk.HasUsbHub;
            desk.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return new OkObjectResult(desk);
        }
    }
}