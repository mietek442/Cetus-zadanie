    using Api.Domain.Models;
    using Api.Infrastructure.DbContext;

    //using Api.Infrastructure.DbContext;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    namespace Api.Features.Desks.Commands.CreateDesk
    {
        public class CreateDeskCommand : IRequest<ActionResult<Desk>>
        {
            public CreateDeskRequest DeskRequest { get; set; }
        }

        public class CreateDeskCommandHandler : IRequestHandler<CreateDeskCommand, ActionResult<Desk>>
        {
            private readonly IApplicationContext _context;

            public CreateDeskCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<ActionResult<Desk>> Handle(CreateDeskCommand request, CancellationToken cancellationToken)
            {
                var desk = new Desk
                {
                    Id = Guid.NewGuid(),
                    Name = request.DeskRequest.Name,
                    Description = request.DeskRequest.Description,
                    PricePerHour = request.DeskRequest.PricePerHour,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Desks.Add(desk);

                await _context.SaveChangesAsync(cancellationToken);

                return new OkObjectResult(desk);
            }
        }
    }