using Api.Infrastructure.Integrations.Deepseek;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            var prompt = $"""
                Na podstawie poniższego tekstu odpowiedz na pytanie:
                "Jaki jest ulubiony kolor?"

                Tekst:
                {request.Text}

                Jeżeli nie da się określić odpowiedzi, napisz:
                "Nie można określić ulubionego koloru."
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