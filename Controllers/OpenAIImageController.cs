using Microsoft.AspNetCore.Mvc;
using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.ResponseModels.ImageResponseModel;

namespace OpenAI.API.Example.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIImageController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;

        public OpenAIImageController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpGet]
        [Route("CreateImage")]
        public async Task<IEnumerable<string>> CreateImage(string question)
        {
            ImageCreateResponse response = await _openAIService.Image.CreateImage(new ObjectModels.RequestModels.ImageCreateRequest
            {
                Prompt = question,
                N = 2,
                Size = StaticValues.ImageStatics.Size.Size256,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "Test"
            });

            return response.Results.Select(p => String.Join("\n", p.Url));
        }

    }
}
