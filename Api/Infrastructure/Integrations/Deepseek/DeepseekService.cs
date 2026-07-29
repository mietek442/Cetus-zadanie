using Deepseek.AspClient.Client;
using Deepseek.AspClient.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Infrastructure.Integrations.Deepseek
{
    public class DeepseekService:IDeepseekService
    {
        private readonly DeepseekClient _client;

        public DeepseekService(DeepseekClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IActionResult> GetDeepseekResponse(string prompt)
        {


            try
            {
                var response = await _client.GenerateResponseAsync(prompt); // pobranie danych 


                var content = response.Choices.FirstOrDefault()?.Message.Content; // z deepseek dukumentacji, wybiera albo pierwszą odpowiedz albo nic 

                if (string.IsNullOrWhiteSpace(content)) // ty;lp sr[pawdzaenie czy jest tu cos 
                {
                    return new NotFoundObjectResult("No response content received from Deepseek.");
                }

                return new OkObjectResult(content);
            }

            catch (DeepseekException ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = (int)ex.StatusCode
                };
            }
        }
    }
}
