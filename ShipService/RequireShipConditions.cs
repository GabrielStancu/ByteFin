using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ShipService.Business.ShipDataCollection;
using ShipService.Business.Timer;

namespace ShipService
{
    public class RequireShipConditions
    {
        private readonly IShipCompartmentsCollector _collector;
        private readonly ILogger _logger;

        public RequireShipConditions(IShipCompartmentsCollector collector,
            ILoggerFactory loggerFactory)
        {
            _collector = collector;
            _logger = loggerFactory.CreateLogger<RequireShipConditions>();
        }

        [Function("RequireShipConditions")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo timerInfo)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var shipCompartments = await _collector.GetCompartmentsAsync();
            var serializedShipCompartments = JsonSerializer.Serialize(shipCompartments);

            _logger.LogInformation($"Collected info about the following ships: {serializedShipCompartments}");

            // TODO: post the ship compartments to queue

            _logger.LogInformation($"Next timer schedule at: {timerInfo.ScheduleStatus?.Next}");
        }
    }
}
