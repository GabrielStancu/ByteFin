using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DataCollectionService.Functions;

public class GenerateEnvironmentConditions
{
    private readonly ILogger _logger;

    public GenerateEnvironmentConditions(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<GenerateEnvironmentConditions>();
    }

    [Function("GenerateEnvironmentConditions")]
    public void Run([ServiceBusTrigger("GenerateEnvDataRequestQueue", Connection = "FUNCTIONS_WORKER_RUNTIME")] string myQueueItem)
    {
        _logger.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
    }
}
