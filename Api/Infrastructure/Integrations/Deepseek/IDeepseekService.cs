using Microsoft.AspNetCore.Mvc;

namespace Api.Infrastructure.Integrations.Deepseek
{
    public interface IDeepseekService
    {
        Task<IActionResult> GetDeepseekResponse(string prompt);
    }
}