using DataCollectionService.Business.Environment.Models;
using DataCollectionService.Business.Models;
using DataCollectionService.Configuration;

namespace DataCollectionService.Business.Environment.Generation;

public class TemperatureGenerator : Generator<Temperature>
{
    private readonly IMeasurementPrefixConfiguration _configuration;

    public TemperatureGenerator(IMeasurementPrefixConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override Temperature Generate(MeasurementParameters parameters, string shipId, string compartmentId)
    {
        var value = GenerateValue(parameters);
        var timestamp = CurrentTime;
        return new Temperature
        {
            Id = GenerateId(_configuration.Humidity, shipId, compartmentId, timestamp),
            ShipId = shipId,
            CompartmentId = compartmentId,
            TimestampUtc = timestamp,
            Deleted = false,
            CelsiusDeg = value
        };
    }
}
