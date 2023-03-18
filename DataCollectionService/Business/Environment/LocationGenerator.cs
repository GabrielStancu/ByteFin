using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;

namespace DataCollectionService.Business.Environment;

public class LocationGenerator : Generator<Location>
{
    private readonly IMeasurementPrefixConfiguration _configuration;
    private readonly IAllowedValuesConfiguration _allowedValues;

    public LocationGenerator(IMeasurementPrefixConfiguration measurementPrefix,
        IAllowedValuesConfiguration allowedValues)
    {
        _configuration = measurementPrefix;
        _allowedValues = allowedValues;
    }

    public override Location Generate(string shipId, string compartmentId)
    {
        var latitude = GenerateValue(_allowedValues.MinLatitude, _allowedValues.MaxLatitude);
        var longitude = GenerateValue(_allowedValues.MinLongitude, _allowedValues.MaxLongitude);
        var timestamp = CurrentTime;

        return new Location
        {
            Id = GenerateId(_configuration.Humidity, shipId, compartmentId, timestamp),
            ShipId = shipId,
            CompartmentId = compartmentId,
            TimestampUtc = timestamp,
            Deleted = false,
            Latitude = latitude,
            Longitude = longitude
        };
    }
}
