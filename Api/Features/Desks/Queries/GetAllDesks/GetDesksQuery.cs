
using Api.Infrastructure.DbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Desks.Queries.GetAllDesks
{
    public class GetDesksQuery : IRequest<ActionResult<List<DeskResult>>>
    {
    }

    public class GetDesksQueryHandler : IRequestHandler<GetDesksQuery, ActionResult<List<DeskResult>>>
    {
        private readonly IApplicationContext _context;
       

        public GetDesksQueryHandler(
            IApplicationContext context
           )
        {
            _context = context;
            
        }

        public async Task<ActionResult<List<DeskResult>>> Handle(
            GetDesksQuery request,
            CancellationToken cancellationToken)
        {
            var desks = await _context.Desks
                .ToListAsync(cancellationToken);

            if (desks == null || desks.Count == 0)
            {
                return new NotFoundResult();
            }

            var deskResponses = desks
                .Select(desk => desk.ToDeskResult())
                .ToList();

            return new OkObjectResult(deskResponses);
        }
    }
}