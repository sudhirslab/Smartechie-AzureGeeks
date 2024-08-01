using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace func
{
    public class MyHttpTrigger
    {
        private readonly ILogger<MyHttpTrigger> _logger;

        public MyHttpTrigger(ILogger<MyHttpTrigger> logger)
        {
            _logger = logger;
        }

        [Function("MyHttpTrigger")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string name = req.Query["name"];
            _logger.LogInformation("GET name:" + name);
            return new OkObjectResult($"Hello, {name}. Welcome to Azure Functions!");
        }
    }
}
