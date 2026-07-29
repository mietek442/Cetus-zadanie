using Api.Infrastructure.Integrations.Deepseek;
using Api.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Api.Features.DeskSearchHelper.Queries
{
    public class HelpSearchDeskQuery : IRequest<ActionResult<HelpSearchDeskResult>>
    {
        public string Text { get; set; } = string.Empty;
    }

    public class HelpSearchDeskQueryHandler : IRequestHandler<HelpSearchDeskQuery, ActionResult<HelpSearchDeskResult>>
    {
        private readonly IDeepseekService _deepseekService;

        public HelpSearchDeskQueryHandler(IDeepseekService deepseekService)
        {
            _deepseekService = deepseekService;
        }

        public async Task<ActionResult<HelpSearchDeskResult>> Handle(
            HelpSearchDeskQuery request,
            CancellationToken cancellationToken)
        {

                {request.Text}

                """;

            var response = await _deepseekService.GetDeepseekResponse(prompt);

            var result = new HelpSearchDeskResult
            {
                DeskId = Guid.Empty,
                Text = response.ToString()
            };

            return new OkObjectResult(response);
        }
    }
}







