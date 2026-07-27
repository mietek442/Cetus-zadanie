using Api.Infrastructure.DbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Desks.Commands.DeleteDesk
{
    public class DeleteDeskCommand : IRequest<ActionResult>
    {
        public Guid DeskId { get; set; }
    }

    public class DeleteDeskCommandHandler : IRequestHandler<DeleteDeskCommand, ActionResult>
    {
        private readonly IApplicationContext _context;

        public DeleteDeskCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Handle(
            DeleteDeskCommand request,
            CancellationToken cancellationToken)
        {
            var desk = await _context.Desks.FindAsync(request.DeskId, cancellationToken);

            if (desk == null)
            {
                return new NotFoundResult();
            }

            _context.Desks.Remove(desk);
            await _context.SaveChangesAsync(cancellationToken);

            return new NoContentResult();
        }
    }
}