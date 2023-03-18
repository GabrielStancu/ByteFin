using DataCollectionService.Business.Environment.Models;
using DataCollectionService.Business.Models;
using DataCollectionService.Configuration;

namespace DataCollectionService.Business.Environment.Generation;

public class HumidityGenerator : Generator<Humidity>
{
    private readonly IMeasurementPrefixConfiguration _configuration;

    public HumidityGenerator(IMeasurementPrefixConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override Humidity Generate(MeasurementParameters parameters, string shipId, string compartmentId)
    {
        var value = GenerateValue(parameters);
        var timestamp = CurrentTime;
        return new Humidity
        {
            Id = GenerateId(_configuration.Humidity, shipId, compartmentId, timestamp),
            ShipId = shipId,
            CompartmentId = compartmentId,
            TimestampUtc = timestamp,
            Deleted = false,
            VaporGramsPerAirKg = value
        };
    }
}
