using Microsoft.AspNetCore.Mvc;
using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;

namespace OpenAI.API.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAICompletionController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;

        public OpenAICompletionController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpGet]
        [Route("CreateCompletion")]
        public async Task<string> CreateCompletion(string question)
        {
            CompletionCreateResponse response = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest
            {
                Prompt = question,
                MaxTokens = 500
            }, Models.TextDavinciV3);

            return response.Choices[0].Text;
        }
    }
}
