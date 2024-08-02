using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyProjFolder
{
    public class GetSettingInfo
    {
        private readonly ILogger<GetSettingInfo> _logger;

        public GetSettingInfo(ILogger<GetSettingInfo> logger)
        {
            _logger = logger;
        }

        [Function("GetSettingInfo")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req, 
            [BlobInput("content/settings.json", Connection = "AzureWebJobsStorage")] string blobContent)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult($"Welcome to Azure Functions! \n {blobContent}");
        }
    }
}
