using System.Text.Json;
using DataCollectionService.Business;
using DataCollectionService.Business.Environment.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ByteFin.Functions;

// TODO: this class will be soon deleted. At the moment it uses the logic to create end data periodically
// But will soon be replaced by a queue listener function, once the queue and publisher are available

public class DataGenerator
{
    private readonly ILogger _logger;
    private readonly IGeneratorService _generatorService;

    public DataGenerator(ILoggerFactory loggerFactory, IGeneratorService generatorService)
    {
        _logger = loggerFactory.CreateLogger<DataGenerator>();
        _generatorService = generatorService;
    }

    [Function(nameof(DataGenerator))]
    public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo timer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        // The next object should be received in queue message in a message bus trigger function
        var environmentParamaters = new EnvironmentParamaters
        {
            ShipId = "ByteFin01",
            CompartmentId = "Gbe01",
            TemperatureParameters = new MeasurementParameters
            {
                MinPossible = -50,
                MaxPossible = 50
            },
            HumidityParameters = new MeasurementParameters
            {
                MinPossible = 0,
                MaxPossible = 100
            },
            LocationParameters = new LocationParameters
            {
                LatitudeParameters = new MeasurementParameters
                {
                    MinPossible = -180,
                    MaxPossible = 180
                },
                LongitudeParameters = new MeasurementParameters
                {
                    MinPossible = -180,
                    MaxPossible = 180
                }
            }
        };
        var environmentConditions = _generatorService.Generate(environmentParamaters);
        var serializedConditions = JsonSerializer.Serialize(environmentConditions);
        _logger.LogInformation($"Received the following conditions:{Environment.NewLine}{serializedConditions}");

        _logger.LogInformation($"Executed function. Next timer schedule at: {timer.ScheduleStatus?.Next ?? DateTime.MaxValue}");
    }
}
