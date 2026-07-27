using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Features.DeskSearchHelper.Queries
{
    public class HelpSearchDeskEndpoint : EndpointBaseAsync
        .WithRequest<HelpSearchDeskRequest>
        .WithActionResult<HelpSearchDeskResult>
    {
        private readonly IMediator _mediator;

        public HelpSearchDeskEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/desks/search-help")]
        [SwaggerOperation(
            Summary = "Search desk by text",
            Description = "Returns a desk search result based on provided text",
            OperationId = "Desk_Search_Help",
            Tags = new[] { "DeskSearch" })]
        public override async Task<ActionResult<HelpSearchDeskResult>> HandleAsync(
            [FromBody] HelpSearchDeskRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(
                new HelpSearchDeskQuery
                {
                    Text = request.Text
                },
                cancellationToken);
        }
    }
}