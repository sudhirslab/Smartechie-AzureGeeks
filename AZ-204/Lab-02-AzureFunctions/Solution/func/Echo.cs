using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace func
{
    public class Echo
    {
        private readonly ILogger<Echo> _logger;

        public Echo(ILogger<Echo> logger)
        {
            _logger = logger;
        }

        [Function("Echo")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string name = req.Query["name"];
            _logger.LogInformation("GET name:" + name);
            return new OkObjectResult($"Hello, {name}. Welcome to Azure Functions!");
        }
    }
}
