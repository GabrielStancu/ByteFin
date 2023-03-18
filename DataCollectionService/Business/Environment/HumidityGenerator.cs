using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;

namespace DataCollectionService.Business.Environment;

public class HumidityGenerator : Generator<Humidity>
{
    private readonly MeasurementPrefixConfiguration _configuration;
    private readonly AllowedValuesConfiguration _allowedValues;

    public HumidityGenerator(MeasurementPrefixConfiguration measurementPrefix,
        AllowedValuesConfiguration allowedValues)
    {
        _configuration = measurementPrefix;
        _allowedValues = allowedValues;
    }

    public override Humidity Generate(string shipId, string compartmentId)
    {
        var value = GenerateValue(_allowedValues.MinHumidity, _allowedValues.MaxHumidity);
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
