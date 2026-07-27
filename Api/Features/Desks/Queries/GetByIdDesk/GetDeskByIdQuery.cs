using Api.Domain.Models;
using Api.Infrastructure.DbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Desks.Queries.GetByIdDesk
{
    public class GetDeskByIdQuery : IRequest<ActionResult<Desk>>
    {
        public Guid Id { get; set; }
    }

    public class GetDeskByIdQueryHandler : IRequestHandler<GetDeskByIdQuery, ActionResult<Desk>>
    {
        private readonly IApplicationContext _context;

        public GetDeskByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Desk>> Handle(
            GetDeskByIdQuery request,
            CancellationToken cancellationToken)
        {
            var desk = await _context.Desks
                .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (desk == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(desk);
        }
    }
}