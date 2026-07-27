using Microsoft.AspNetCore.Mvc;

namespace Api.Features.DeskSearchHelper.Queries
{
    public class HelpSearchDeskRequest
    {
        [FromQuery(Name = "text")]
        public string Text { get; set; } = string.Empty;
    }
}
