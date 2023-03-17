using DataCollectionService.Business;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ByteFin.Functions
{
    public class DataGenerator
    {
        private readonly ILogger _logger;

        public DataGenerator(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DataGenerator>();
        }

        [Function("DataGenerator")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo timer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {timer.ScheduleStatus.Next}");
        }
    }
}
