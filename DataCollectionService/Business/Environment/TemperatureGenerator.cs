using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;

namespace DataCollectionService.Business.Environment;

public class TemperatureGenerator : Generator<Temperature>
{
    private readonly IMeasurementPrefixConfiguration _measurementPrefix;
    private readonly IAllowedValuesConfiguration _allowedValues;

    public TemperatureGenerator(IMeasurementPrefixConfiguration measurementPrefix,
        IAllowedValuesConfiguration allowedValues)
    {
        _measurementPrefix = measurementPrefix;
        _allowedValues = allowedValues;
    }

    public override Temperature Generate(string shipId, string compartmentId)
    {
        var value = GenerateValue(_allowedValues.MinTemperature, _allowedValues.MaxTemperature);
        var timestamp = CurrentTime;
        return new Temperature
        {
            Id = GenerateId(_measurementPrefix.Humidity, shipId, compartmentId, timestamp),
            ShipId = shipId,
            CompartmentId = compartmentId,
            TimestampUtc = timestamp,
            Deleted = false,
            CelsiusDeg = value
        };
    }
}
